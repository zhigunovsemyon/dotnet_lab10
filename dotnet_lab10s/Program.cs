using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using MovieLibrary;

namespace Server;

static class Program
{

	private static readonly TimeSpan _saveInterval = TimeSpan.FromSeconds(10.0);
	private const string _filename = "movies.json";

	private static readonly JsonSerializerOptions _options = new() { AllowTrailingCommas = true, WriteIndented = true };

	/// <summary> Список фильмов </summary>
	private static ConcurrentDictionary<string, Movie> _movieList = new();

	/// <summary> Адрес и порт для прослушивания </summary>
	static readonly IPEndPoint listenTo = new IPEndPoint(IPAddress.IPv6Any, 9876);

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
			var json = JsonSerializer.Serialize(_movieList, _options);
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

		_movieList = JsonSerializer.Deserialize<ConcurrentDictionary<string, Movie>>(json, _options) ?? new();
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
				WorkWithRemoteString(Encoding.UTF8.GetString(buf, 0, recieved));
			} while (true);
		}
		catch (Exception ex) {
			Console.Error.WriteLine($"Ошибка соединения: {ex.Message}");
		}
		finally {
			sock.Close();
		}
	}

	private static void WorkWithRemoteString(string remoteString)
	{
		try {
			var request = JsonSerializer.Deserialize<MovieLibrary.MovieRequest>(remoteString)
				?? throw new Exception("WorkWithRemoteString: JsonSerializer.Deserialize вернул null!");
			switch (request.Request) {
			case MovieRequest.RequestType.Get:
				Console.WriteLine(GetMovie(request.Movie)?.ToString() ?? "no");
				break;
			case MovieRequest.RequestType.Add:
				Console.WriteLine("Add: {0}", AddMovie(request.Movie));
				break;
			case MovieRequest.RequestType.Update:
				Console.WriteLine("Update: {0}", UpdateMovie(request.Movie));
				break;
			case MovieRequest.RequestType.Delete:
				Console.WriteLine("Update: {0}", DeleteMovie(request.Movie));
				break;
			default:
				throw new NotImplementedException("WorkWithRemoteString: request.Request неизвестного типа!");
			}
		} catch (Exception ex) {
			Console.Error.WriteLine($"Ошибка при обработке: {ex.Message}");
		}
	}

	/// <summary> Добавление новой записи или замена старой </summary>
	/// <param name="movie">Новая запись</param>
	/// <returns> true при удачном добавлении, false при ошибке </returns>
	private static bool UpdateMovie(Movie movie)
	{
		string key = movie.Title.ToLower();
		if (_movieList.TryGetValue(key, out var oldMovie)) {
			_movieList.TryUpdate(key, movie, oldMovie);
			return true;
		}
		return AddMovie(movie);
	}

	/// <summary> Добавление новой записи </summary>
	/// <param name="movie">Новая запись</param>
	/// <returns> true при удачном добавлении, false если такая запись уже есть </returns>
	private static bool AddMovie(Movie movie)
	{
		string key = movie.Title.ToLower();
		return _movieList.TryAdd(key, movie);
	}

	/// <summary> Удаление записи </summary>
	/// <param name="movie">Запись</param>
	/// <returns> true при удачном удалении, false при ошибке </returns>
	private static bool DeleteMovie(Movie movie)
	{
		string key = movie.Title.ToLower();
		return _movieList.TryRemove(key, out _);
	}

	/// <summary> Поиск записи </summary>
	/// <param name="movie">Неполная запись с названием </param>
	/// <returns> Запись при обнаружении, либо null </returns>
	private static Movie? GetMovie(Movie movieKey)
	{
		string key = movieKey.Title.ToLower();
		return _movieList.TryGetValue(key, out var movie) ? movie : null;
	}
}
