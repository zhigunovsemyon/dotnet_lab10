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
		Update
	}

	/// <summary> Запрос </summary>
	public RequestType Request {  get; set; } = RequestType.Get;

	/// <summary> Новые данные о фильме </summary>
	public Movie? Movie { get; set; }
}
