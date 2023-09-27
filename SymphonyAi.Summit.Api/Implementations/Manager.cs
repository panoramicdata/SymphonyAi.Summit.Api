﻿using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SymphonyAi.Summit.Api.Implementations;

internal class Manager
{
	protected static readonly string ApiIntegrationSubUrl = "REST/Summit_RESTWCF.svc/RESTService/CommonWS_JsonObjCall_json";

	protected HttpClient HttpClient { get; }

	protected string ApiKey { get; }

	protected JsonSerializerOptions JsonSerializerOptions { get; }

	protected ILogger Logger { get; }

	public Manager(
		HttpClient httpClient,
		string apiKey,
		JsonSerializerOptions jsonSerializerOptions,
		ILogger logger
	)
	{
		HttpClient = httpClient;
		ApiKey = apiKey;
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
			"RESPONSE ({HttpStatusCode}): '{FormattedJson}'",
			(int)httpResponseMessage.StatusCode,
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