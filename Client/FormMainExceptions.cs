namespace Client.FormMainExceptions;

class InvalidId : Exception
{
	public InvalidId() { }
	public InvalidId(string? message) : base(message) { }
	public InvalidId(string? message, Exception? innerException) : base(message, innerException) { }
}

class InvalidResponse : Exception
{
	public InvalidResponse() { }
	public InvalidResponse(string? message) : base(message) { }
	public InvalidResponse(string? message, Exception? innerException) : base(message, innerException) { }

}