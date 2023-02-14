using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Exceptions;
using SymphonyAi.Summit.Api.Interfaces;
using SymphonyAi.Summit.Api.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class IncidentManager : Manager, IIncidents
{
	private readonly JsonSerializerOptions _jsonSerializerOptions;
	private readonly ILogger _logger;

	public IncidentManager(
		HttpClient httpClient,
		string apiKey,
		JsonSerializerOptions jsonSerializerOptions,
		ILogger logger)
		: base(httpClient, apiKey)
	{
		_jsonSerializerOptions = jsonSerializerOptions;
		_logger = logger;
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
	) where TRequest : IncidentRequest
	{
		request.CommonParameters.ProxyDetails.ApiKey = ApiKey;
		//var requestJson = JsonSerializer
		//	.Serialize(request, _jsonSerializerOptions);
		var response = await HttpClient
			.PostAsJsonAsync(string.Empty, request, _jsonSerializerOptions, cancellationToken);
		//var responseString = await response
		//	.Content
		//	.ReadAsStringAsync(cancellationToken);
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
		//var requestJson = JsonSerializer
		//	.Serialize(request, _jsonSerializerOptions);
		var response = await HttpClient
			.PostAsJsonAsync(string.Empty, request, _jsonSerializerOptions, cancellationToken);
		var responseString = await response
			.Content
			.ReadAsStringAsync(cancellationToken);
		_logger.LogDebug(responseString);

		var returnValue = await response
			.Content
			.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {typeof(TResponse).Name}");
		return returnValue;
	}
}
