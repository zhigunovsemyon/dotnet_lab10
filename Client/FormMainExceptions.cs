namespace Client.FormMainExceptions;

class InvalidId : Exception
{
	public InvalidId() { }
	public InvalidId(string? message) : base(message) { }
	public InvalidId(string? message, Exception? innerException) : base(message, innerException) { }
}
