namespace MovieLibrary;

/// <summary> Запись о фильме </summary>
public class Movie
{
	private string _title = "";
	private string _genre = "";

	/// <summary> Название </summary>
	public string Title
	{
		get => _title;
		set
		{
			if (String.IsNullOrWhiteSpace(value)) {
				throw new MovieException.InvalidMovieTitle("Не указано название фильма");
			} else { 
				_title = value.Trim();
			}
		} 
	}

	/// <summary> Жанр </summary>
	public string Genre
	{
		get => _genre;
		set
		{
			if (String.IsNullOrWhiteSpace(value)) {
				throw new MovieException.InvalidMovieTitle("Не указано название фильма");
			} else {
				_genre = value.Trim();
			}
		}
	}

	/// <summary> Год выпуска </summary>
	public Int16 Year { get; set; }

	/// <summary> Пустой конструктор </summary>
	public Movie () { }

	/// <summary> Конструктор с параметрами </summary>
	public Movie (string title, string genre, Int16 year)
	{
		this.Title = title;
		this.Genre = genre;
		this.Year = year;
	}

	public override string ToString () => $"Название: {this.Title}, жанр: {this.Genre}, год: {this.Year}";
}
