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

	private static readonly JsonSerializerOptions _options = new() { WriteIndented = true};

	/// <summary> Список фильмов </summary>
	private static ConcurrentDictionary<int, Movie> _movieList = new();

	/// <summary> Адрес и порт для прослушивания </summary>
	static readonly IPEndPoint listenTo = new IPEndPoint(IPAddress.IPv6Any, 9876);

	static void Main (string[] args)
	{
		LoadFile();
		PrintMovieList();

		new Task (SaveFile).Start();

		var listener = new Socket(listenTo.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		listener.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);

		try {
			listener.Bind(listenTo);
			listener.Listen(10);

			do {
				Console.WriteLine("Ожидание соединения на {0}", listenTo);
				var connSock = listener.Accept();
				Console.WriteLine("Подключение от: {0}",connSock.RemoteEndPoint);


				new Task(Connection, connSock).Start();
			} while (true);
		} catch { }
	}

	/// <summary> Сохранение списка в файл </summary>
	private static void SaveFile ()
	{
		do {
			Thread.Sleep(_saveInterval);
			var json = JsonSerializer.Serialize(_movieList, _options);
			File.WriteAllText (_filename, json);
			Console.WriteLine("Список сохранён в файл {0}", _filename);
		} while (true);
	}

	/// <summary> Чтение файла со списком </summary>
	private static void LoadFile ()
	{
		var json = "{}";
		try {
			json = File.ReadAllText(_filename);
		}
		catch { }

		_movieList = JsonSerializer.Deserialize<ConcurrentDictionary<int, Movie>>(json, _options) ?? new();
	}

	/// <summary> Вывод списка фильмов </summary>
	private static void PrintMovieList ()
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
	private static void Connection (object? o)
	{
		var sock = o as Socket ?? throw new InvalidCastException("Program.Connection: o должен быть типа Socket");
		sock.Send(Encoding.UTF8.GetBytes("Hello"));

		Thread.Sleep(TimeSpan.FromMinutes(1));

		sock.Shutdown(SocketShutdown.Both);
		sock.Close();
	}
}
