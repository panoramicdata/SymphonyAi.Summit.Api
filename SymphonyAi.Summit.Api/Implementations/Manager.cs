namespace SymphonyAi.Summit.Api.Implementations;

internal class Manager
{
	protected HttpClient HttpClient { get; }

	protected string ApiKey { get; }

	public Manager(HttpClient httpClient, string apiKey)
	{
		HttpClient = httpClient;
		ApiKey = apiKey;
	}
}