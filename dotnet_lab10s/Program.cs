using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using MovieLibrary;

namespace Server;

static class Program
{
	/// <summary> Таймаут сохранения </summary>
	private static readonly TimeSpan _saveInterval = TimeSpan.FromSeconds(10.0);

	/// <summary>  Стандартное название базы с фильмами </summary>
	private const string _filename = "movies.json";

	/// <summary> Параметры json для файла с фильмами </summary>
	private static readonly JsonSerializerOptions _optionsOnSave = new()
	{
		AllowTrailingCommas = true,
		WriteIndented = true
	};

	/// <summary> Ответ сервера на запрос </summary>
	//private static readonly MovieResponse _response = new();

	/// <summary> Список фильмов </summary>
	private static ConcurrentDictionary<string, Movie> _movieList = new();

	/// <summary> Адрес и порт для прослушивания </summary>
	static readonly IPEndPoint listenTo = new(IPAddress.IPv6Any, 9876);

	static void Main(string[] args)
	{
		LoadFile();
		PrintMovieList();

		new Task(SaveFile).Start();

		var listener = new Socket(listenTo.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		listener.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);

		try {
			listener.Bind(listenTo);
			listener.Listen(10);

			do {
				Console.WriteLine("Ожидание соединения на {0}", listenTo);
				var connSock = listener.Accept();
				Console.WriteLine("Подключение от: {0}", connSock.RemoteEndPoint);


				new Task(Connection, connSock).Start();
			} while (true);
		}
		catch { }
	}

	/// <summary> Сохранение списка в файл </summary>
	private static void SaveFile()
	{
		do {
			Thread.Sleep(_saveInterval);
			var json = JsonSerializer.Serialize(_movieList, _optionsOnSave);
			File.WriteAllText(_filename, json);
			Console.WriteLine("Список сохранён в файл {0}", _filename);
		} while (true);
	}

	/// <summary> Чтение файла со списком </summary>
	private static void LoadFile()
	{
		var json = "{}";
		try {
			json = File.ReadAllText(_filename);
		}
		catch { }

		_movieList = JsonSerializer.Deserialize<ConcurrentDictionary<string, Movie>>(json, _optionsOnSave) ?? new();
	}

	/// <summary> Вывод списка фильмов </summary>
	private static void PrintMovieList()
	{
		if (_movieList.IsEmpty) {
			Console.WriteLine("Список пуст!");
			return;
		}
		foreach (var (_, movieValue) in _movieList) {
			Console.WriteLine(movieValue);
		}
	}

	/// <summary>
	/// Метод, выполняемый в отдельном потоке для каждого соеднинения
	/// </summary>
	/// <param name="o"> Сокет подключения </param>
	/// <exception cref="InvalidCastException"> При o == null или o отличном от System.Net.Sockets.Socket </exception>
	private static void Connection(object? o)
	{
		var sock = o as Socket ?? throw new InvalidCastException("Program.Connection: o должен быть типа Socket");
		try {
			do {
				var buf = new byte[1024];
				var recieved = sock.Receive(buf);
				if (0 == recieved) {
					break;
				}

				var response = WorkWithRemoteString(Encoding.UTF8.GetString(buf, 0, recieved));
				
			} while (true);
		}
		catch (Exception ex) {
			Console.Error.WriteLine($"Ошибка соединения: {ex.Message}");
		}
		finally {
			sock.Close();
		}
	}

	/// <summary> Создание объекта ответа на основе запроса </summary>
	/// <param name="remoteString">Строка с запросом</param>
	/// <returns> Объект ответа </returns>
	private static MovieResponse WorkWithRemoteString(string remoteString)
	{
		try {
			var request = JsonSerializer.Deserialize<MovieLibrary.MovieRequest>(remoteString)
				?? throw new Exception("WorkWithRemoteString: JsonSerializer.Deserialize вернул null!");
			return request.Request switch
			{
				MovieRequest.RequestType.Get => GetMovie(request.Movie),
				MovieRequest.RequestType.Add => AddMovie(request.Movie),
				MovieRequest.RequestType.Update => UpdateMovie(request.Movie),
				MovieRequest.RequestType.Delete => DeleteMovie(request.Movie),
				_ => new MovieResponse() 
				{ 
					Movie = null, 
					Response = MovieResponse.ResponseType.UnknownRequest 
				}
			};
		}
		catch (Exception ex) {
			Console.Error.WriteLine($"Ошибка при обработке: {ex.Message}");
			return new MovieResponse() { Movie = null, Response = MovieResponse.ResponseType.Error };
		}
	}

	/// <summary> Добавление новой записи или замена старой </summary>
	/// <param name="movie">Новая запись</param>
	/// <returns> 
	/// Ответ с информацией об удачном или неудачном обновлении,
	/// либо соответствующая информация о добавлении, если нет старой записи
	/// </returns>
	private static MovieResponse UpdateMovie(Movie movie)
	{
		string key = movie.Title.ToLower();
		if (_movieList.TryGetValue(key, out var oldMovie)) {
			return (_movieList.TryUpdate(key, movie, oldMovie))
				? new MovieResponse() { Response = MovieResponse.ResponseType.Updated, Movie = null }
				: new MovieResponse() { Response = MovieResponse.ResponseType.NotUpdated, Movie = null };
		}
		return AddMovie(movie);
	}

	/// <summary> Добавление новой записи </summary>
	/// <param name="movie">Новая запись</param>
	/// <returns> Ответ с информацией об удачном или неудачном добавлении </returns>
	private static MovieResponse AddMovie(Movie movie)
	{
		string key = movie.Title.ToLower();
		return (_movieList.TryAdd(key, movie))
			? new MovieResponse() { Response = MovieResponse.ResponseType.Added, Movie = null }
			: new MovieResponse() { Response = MovieResponse.ResponseType.NotAdded, Movie = null };
	}

	/// <summary> Удаление записи </summary>
	/// <param name="movie">Запись</param>
	/// <returns> Ответ с информацией об удачном или неудачном удалении </returns>
	private static MovieResponse DeleteMovie(Movie movie)
	{
		string key = movie.Title.ToLower();
		return (_movieList.TryRemove(key, out _))
			? new MovieResponse() { Response = MovieResponse.ResponseType.Deleted, Movie = null }
			: new MovieResponse() { Response = MovieResponse.ResponseType.NotDeleted, Movie = null };
	}

	/// <summary> Поиск записи </summary>
	/// <param name="movie">Неполная запись с названием </param>
	/// <returns> Ответ с фильмом, либо информацией о его отсутствии </returns>
	private static MovieResponse GetMovie(Movie movieKey)
	{
		string key = movieKey.Title.ToLower();
		return (_movieList.TryGetValue(key, out var foundMovie))
			? new MovieResponse() { Movie = foundMovie, Response = MovieResponse.ResponseType.Found }
			: new MovieResponse() { Movie = null, Response = MovieResponse.ResponseType.NotFound };
	}
}
