namespace MovieLibrary;

/// <summary> Запись о фильме </summary>
public class Movie
{
	/// <summary> Название </summary>
	public string Title { get; set; } = "";

	/// <summary> Жанр </summary>
	public string Genre { get; set; } = "";

	/// <summary> Год выпуска </summary>
	public Int16 Year { get; set; } = -1;

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
