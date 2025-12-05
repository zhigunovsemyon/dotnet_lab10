namespace MovieLibrary;

/// <summary> Запрос от клиента серверу </summary>
public class MovieRequest
{
	/// <summary>
	/// Возможные запросы
	/// </summary>
	public enum RequestType
	{
		Get,
		Delete,
		Add,
		Update,
		Quit
	}

	/// <summary> Запрос </summary>
	public RequestType Request {  get; set; }

	/// <summary> Новые данные о фильме </summary>
	public Movie? Movie { get; set; }
}
