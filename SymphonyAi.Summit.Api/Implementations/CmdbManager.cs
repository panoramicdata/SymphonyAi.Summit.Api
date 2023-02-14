﻿using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Exceptions;
using SymphonyAi.Summit.Api.Interfaces;
using SymphonyAi.Summit.Api.Models.Cmdb;
using System.Net.Http.Json;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class CmdbManager : Manager, ICmdb
{
	public CmdbManager(
		HttpClient httpClient,
		string apiKey,
		JsonSerializerOptions jsonSerializerOptions,
		ILogger logger)
		: base(httpClient, apiKey, jsonSerializerOptions, logger)
	{
	}

	public Task<CmdbCreateOrUpdateCiResponse> CreateOrUpdateCiAsync(
		CmdbCreateOrUpdateCiRequest request,
		CancellationToken cancellationToken)
		=> GetAsync<CmdbCreateOrUpdateCiRequest, CmdbCreateOrUpdateCiResponse>(request, cancellationToken);

	public Task<CmdbQueryResponse> GetCisAsync(
		CmdbQueryRequest request,
		CancellationToken cancellationToken)
		=> GetAsync2<CmdbQueryRequest, CmdbQueryResponse>(request, cancellationToken);

	public Task<CmdbQueryResponse> GetCis2Async(
		CmdbQueryRequest request,
		CancellationToken cancellationToken)
		=> GetAsync2<CmdbQueryRequest, CmdbQueryResponse>(request, cancellationToken);

	private async Task<TResponse> GetAsync<TRequest, TResponse>(
		TRequest request,
		CancellationToken cancellationToken
	) where TRequest : CmdbCreateOrUpdateCiRequest
	{
		request.CommonParameters.ProxyDetails.ApiKey = ApiKey;

		LogRequest(request);

		var response = await HttpClient
			.PostAsJsonAsync(string.Empty, request, JsonSerializerOptions, cancellationToken);

		await LogResponseAsync(response, cancellationToken);

		var returnValue = await response
			.Content
			.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {typeof(TResponse).Name}");
		return returnValue;
	}

	private async Task<TResponse> GetAsync2<TRequest, TResponse>(
	TRequest request,
	CancellationToken cancellationToken
	) where TRequest : CmdbQueryRequest
	{
		request.CommonParameters.ApiKey = ApiKey;
		var requestJson = JsonSerializer
			.Serialize(request, JsonSerializerOptions);
		Logger.LogDebug("REQUEST: " + requestJson);
		var response = await HttpClient
			.PostAsJsonAsync(string.Empty, request, JsonSerializerOptions, cancellationToken);

		await LogResponseAsync(response, cancellationToken);

		var returnValue = await response
			.Content
			.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {typeof(TResponse).Name}");
		return returnValue;
	}
}
