using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Interfaces;
using SymphonyAi.Summit.Api.Models;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class IncidentManager(
	HttpClient httpClient,
	string apiKey,
	string apiIntegrationSubUrl,
	JsonSerializerOptions jsonSerializerOptions,
	ILogger logger) : Manager(
		httpClient,
		apiKey,
		apiIntegrationSubUrl,
		jsonSerializerOptions,
		logger), IIncidents
{
	public Task<GetIncidentListResponse> GetIncidentListAsync(
		GetIncidentListRequest request,
		CancellationToken cancellationToken)
		=> SendAsync<GetIncidentListResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);

	public Task<GetIncidentListResponse> GetIncidentListDetailsAsync(
		GetIncidentListDetailsRequest request,
		CancellationToken cancellationToken)
		=> SendAsync<GetIncidentListResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);

	public Task<GetIncidentDetailsAndChangeHistoryResponse> GetIncidentDetailsAndChangeHistoryAsync(
		GetIncidentDetailsAndChangeHistoryRequest request,
		CancellationToken cancellationToken)
		=> SendAsync<GetIncidentDetailsAndChangeHistoryResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);

	public Task<CreateOrUpdateIncidentResponse> CreateOrUpdateIncidentAsync(
		CreateOrUpdateIncidentRequest request,
		CancellationToken cancellationToken)
		=> SendAsync<CreateOrUpdateIncidentResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);
}
