using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Exceptions;
using SymphonyAi.Summit.Api.Interfaces;
using SymphonyAi.Summit.Api.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class IncidentManager : Manager, IIncidents
{
	public IncidentManager(
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
	public Task<GetIncidentListResponse> GetIncidentListAsync(
			GetIncidentListRequest request,
			CancellationToken cancellationToken)
			=> GetAsync<GetIncidentListRequest, GetIncidentListResponse>(
				request,
				cancellationToken);

	public Task<GetIncidentListResponse> GetIncidentListDetailsAsync(
		GetIncidentListDetailsRequest request,
		CancellationToken cancellationToken)
		=> GetAsync<GetIncidentListDetailsRequest, GetIncidentListResponse>(
			request,
			cancellationToken);

	public Task<GetIncidentDetailsAndChangeHistoryResponse> GetIncidentDetailsAndChangeHistoryAsync(
		GetIncidentDetailsAndChangeHistoryRequest request,
		CancellationToken cancellationToken)
		=> GetAsync<GetIncidentDetailsAndChangeHistoryRequest, GetIncidentDetailsAndChangeHistoryResponse>(
			request,
			cancellationToken);

	public Task<CreateOrUpdateIncidentResponse> CreateOrUpdateIncidentAsync(
		CreateOrUpdateIncidentRequest request,
		CancellationToken cancellationToken)
		=> PostAsync<CreateOrUpdateIncidentRequest, CreateOrUpdateIncidentResponse>(request,
			cancellationToken);

	private async Task<TResponse> GetAsync<TRequest, TResponse>(
		TRequest request,
		CancellationToken cancellationToken
	) where TRequest : IIncidentRequest
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

	private async Task<TResponse> PostAsync<TRequest, TResponse>(
		TRequest request,
		CancellationToken cancellationToken
	) where TRequest : CreateOrUpdateIncidentRequest
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
}
