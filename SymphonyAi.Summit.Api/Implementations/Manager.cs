using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SymphonyAi.Summit.Api.Implementations;

internal class Manager(
	HttpClient httpClient,
	string apiKey,
	string apiIntegrationSubUrl,
	JsonSerializerOptions jsonSerializerOptions,
	ILogger logger
	)
{
	protected string ApiIntegrationSubUrl { get; private set; } = apiIntegrationSubUrl.TrimEnd('/') + "/REST/Summit_RESTWCF.svc/RESTService/CommonWS_JsonObjCall_json";

	protected HttpClient HttpClient { get; } = httpClient;

	protected string ApiKey { get; } = apiKey;

	protected JsonSerializerOptions JsonSerializerOptions { get; } = jsonSerializerOptions;

	protected ILogger Logger { get; } = logger;

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