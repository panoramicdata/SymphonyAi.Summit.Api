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
		string apiIntegrationSubUrl,
		JsonSerializerOptions jsonSerializerOptions,
		ILogger logger)
		: base(
			httpClient,
			apiKey,
			apiIntegrationSubUrl,
			jsonSerializerOptions,
			logger)
	{
	}

	public async Task<CmdbCreateOrUpdateCiResponse> CreateCiAsync(
		CmdbCreateCiRequest request,
		CancellationToken cancellationToken)
	{
		request.CommonParameters.ProxyDetails.ApiKey = ApiKey;

		LogRequest(request);

		var response = await HttpClient
			.PostAsJsonAsync(ApiIntegrationSubUrl, request, JsonSerializerOptions, cancellationToken);

		await LogResponseAsync(response, cancellationToken);

		var returnValue = await response
		.Content
			.ReadFromJsonAsync<CmdbCreateOrUpdateCiResponse>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {nameof(CmdbCreateOrUpdateCiResponse)}");
		return returnValue;
	}

	public async Task<CmdbCreateOrUpdateCiResponse> UpdateCiAsync(
		CmdbUpdateCiRequest request,
		CancellationToken cancellationToken)
	{
		{
			request.CommonParameters.ProxyDetails.ApiKey = ApiKey;

			LogRequest(request);

			var response = await HttpClient
				.PostAsJsonAsync(ApiIntegrationSubUrl, request, JsonSerializerOptions, cancellationToken);

			await LogResponseAsync(response, cancellationToken);

			var returnValue = await response
			.Content
				.ReadFromJsonAsync<CmdbCreateOrUpdateCiResponse>(cancellationToken: cancellationToken)
				?? throw new SummitApiException($"Error deserializing {nameof(CmdbCreateOrUpdateCiResponse)}");
			return returnValue;
		}
	}

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

	public Task<CmdbCustomersResponse> GetCustomersAsync(
		CmdbCustomersRequest request,
		CancellationToken cancellationToken)
		=> throw new NotSupportedException();

	private async Task<TResponse> GetCisAsync<TRequest, TResponse>(
	TRequest request,
	CancellationToken cancellationToken
	) where TRequest : CmdbRequestBase
	{
		request.CommonParameters.ProxyDetails.ApiKey = ApiKey;

		LogRequest(request);

		var response = await HttpClient
			.PostAsJsonAsync(ApiIntegrationSubUrl, request, JsonSerializerOptions, cancellationToken);

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
			.PostAsJsonAsync(ApiIntegrationSubUrl, request, JsonSerializerOptions, cancellationToken);

		await LogResponseAsync(response, cancellationToken);

		var returnValue = await response
			.Content
			.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {typeof(TResponse).Name}");
		return returnValue;
	}

	public async Task<CmdbCreateRelationshipResponse> CreateRelationshipAsync(CmdbCreateRelationshipRequest request, CancellationToken cancellationToken)
	{
		request.CommonParameters.ProxyDetails.ApiKey = ApiKey;

		LogRequest(request);

		var response = await HttpClient
			.PostAsJsonAsync(ApiIntegrationSubUrl, request, JsonSerializerOptions, cancellationToken);

		await LogResponseAsync(response, cancellationToken);

		var returnValue = await response
		.Content
			.ReadFromJsonAsync<CmdbCreateRelationshipResponse>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {nameof(CmdbCreateRelationshipResponse)}");

		return returnValue;
	}

	public async Task<CmdbDeleteRelationshipResponse> DeleteRelationshipAsync(CmdbDeleteRelationshipRequest request, CancellationToken cancellationToken)
	{
		request.CommonParameters.ProxyDetails.ApiKey = ApiKey;

		LogRequest(request);

		var response = await HttpClient
			.PostAsJsonAsync(ApiIntegrationSubUrl, request, JsonSerializerOptions, cancellationToken);

		await LogResponseAsync(response, cancellationToken);

		var returnValue = await response
		.Content
			.ReadFromJsonAsync<CmdbDeleteRelationshipResponse>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {nameof(CmdbCreateRelationshipResponse)}");
		return returnValue;
	}

	public async Task<CmdbGetRelationshipsQueryResponse> GetRelationshipsAsync(
		CmdbRelationshipQueryRequest request,
		CancellationToken cancellationToken
	)
	{
		request.CommonParameters.ProxyDetails.ApiKey = ApiKey;

		LogRequest(request);

		var response = await HttpClient
			.PostAsJsonAsync(ApiIntegrationSubUrl, request, JsonSerializerOptions, cancellationToken);

		await LogResponseAsync(response, cancellationToken);

		var returnValue = await response
		.Content
			.ReadFromJsonAsync<CmdbGetRelationshipsQueryResponse>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {nameof(CmdbGetRelationshipsQueryResponse)}");

		return returnValue;
	}
}
