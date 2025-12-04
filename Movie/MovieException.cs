namespace MovieLibrary.MovieException;

public class InvalidMovieTitle : Exception
{
	public InvalidMovieTitle () { }
	public InvalidMovieTitle (string? message) : base(message) { }
	public InvalidMovieTitle (string? message, Exception? innerException) : base(message, innerException) { }
}

public class InvalidMovieGenre : Exception
{
	public InvalidMovieGenre () { }
	public InvalidMovieGenre (string? message) : base(message) { }
	public InvalidMovieGenre (string? message, Exception? innerException) : base(message, innerException) { }
}

/// <summary> Ошибка неправильного года выпуска </summary>
public class InvalidMovieYear : Exception
{
	public InvalidMovieYear() : base() { }

	public InvalidMovieYear(string? message) : base(message) { }

	public InvalidMovieYear(string? message, Exception? innerException)
		: base(message, innerException) { }
}