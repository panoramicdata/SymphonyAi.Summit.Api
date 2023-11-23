namespace SymphonyAi.Summit.Api.Exceptions;
public class SummitApiException : Exception
{
	public SummitApiException(string message) : base(message)
	{
	}

	public SummitApiException(string message, Exception innerException) : base(message, innerException)
	{
	}
}
