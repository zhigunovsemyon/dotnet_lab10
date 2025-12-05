namespace MovieLibrary;

/// <summary> Ответ сервера клиенту </summary>
public class MovieResponse
{
	/// <summary> Возможные ответы </summary>
	public enum ResponseType
	{
		Found,
		Added,
		Updated,
		Deleted,
		NotFound,
		NotAdded,
		NotUpdated,
		NotDeleted,
		UnknownRequest,
		Error
	}

	/// <summary> Ответ </summary>
	public ResponseType Response { get; set; } = ResponseType.NotFound;

	/// <summary> Данные о фильме </summary>
	public Movie? Movie { get; set; } = null;
}
