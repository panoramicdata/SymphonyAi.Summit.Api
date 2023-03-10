using Microsoft.Extensions.Logging;
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
		=> CreateOrUpdateAsync<CmdbCreateOrUpdateCiRequest, CmdbCreateOrUpdateCiResponse>(request, cancellationToken);

	public Task<CmdbCiResponse> GetCiAsync(
		CmdbCiRequest request,
		CancellationToken cancellationToken)
		=> GetCisAsync<CmdbCiRequest, CmdbCiResponse>(request, cancellationToken);

	public Task<CmdbQueryResponse> GetCisAsync(
		CmdbQueryRequest request,
		CancellationToken cancellationToken)
		=> GetCisAsync<CmdbQueryRequest, CmdbQueryResponse>(request, cancellationToken);

	public Task<CmdbQueryResponse> GetCis2Async(
		CmdbQuery2Request request,
		CancellationToken cancellationToken)
		=> GetCis2Async<CmdbQuery2Request, CmdbQueryResponse>(request, cancellationToken);

	private async Task<TResponse> CreateOrUpdateAsync<TRequest, TResponse>(
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

	private async Task<TResponse> GetCisAsync<TRequest, TResponse>(
	TRequest request,
	CancellationToken cancellationToken
	) where TRequest : CmdbRequestBase
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

	private async Task<TResponse> GetCis2Async<TRequest, TResponse>(
	TRequest request,
	CancellationToken cancellationToken
	) where TRequest : CmdbQuery2Request
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
}
