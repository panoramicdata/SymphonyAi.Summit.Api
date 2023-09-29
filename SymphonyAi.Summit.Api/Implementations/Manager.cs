using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SymphonyAi.Summit.Api.Implementations;

internal class Manager
{
	protected string ApiIntegrationSubUrl { get; private set; }

	protected HttpClient HttpClient { get; }

	protected string ApiKey { get; }

	protected JsonSerializerOptions JsonSerializerOptions { get; }

	protected ILogger Logger { get; }

	public Manager(
		HttpClient httpClient,
		string apiKey,
		string apiIntegrationSubUrl,
		JsonSerializerOptions jsonSerializerOptions,
		ILogger logger
	)
	{
		HttpClient = httpClient;
		ApiKey = apiKey;
		ApiIntegrationSubUrl = apiIntegrationSubUrl;
		JsonSerializerOptions = jsonSerializerOptions;
		Logger = logger;
	}

	protected async Task LogResponseAsync(
		HttpResponseMessage httpResponseMessage,
		CancellationToken cancellationToken
	)
	{
		var responseString = await httpResponseMessage
		.Content
		.ReadAsStringAsync(cancellationToken);

		string formattedJson;
		try
		{
			formattedJson = JsonSerializerOptions.WriteIndented
			? JsonSerializer
			.Serialize(JsonNode.Parse(responseString), JsonSerializerOptions)
			: responseString;
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, "Error formatting JSON");
			formattedJson = responseString;
		}

		Logger.Log(
			httpResponseMessage.IsSuccessStatusCode ? LogLevel.Debug : LogLevel.Error,
			"RESPONSE ({HttpStatusCode} from {HttpClientBaseAddress}/{ApiIntegrationSubUrl}): '{FormattedJson}'",
			(int)httpResponseMessage.StatusCode,
			HttpClient.BaseAddress,
			ApiIntegrationSubUrl,
			formattedJson
		);
	}

	protected void LogRequest(object request)
	{
		var formattedJson = JsonSerializer
			.Serialize(request, JsonSerializerOptions);

		Logger.LogDebug(
			"REQUEST: {FormattedJson}",
			formattedJson
		);
	}
}