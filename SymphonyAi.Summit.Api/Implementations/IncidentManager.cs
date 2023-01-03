using SymphonyAi.Summit.Api.Exceptions;
using SymphonyAi.Summit.Api.Interfaces;
using SymphonyAi.Summit.Api.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class IncidentManager : Manager, IIncidents
{
	public IncidentManager(HttpClient httpClient, string apiKey)
		: base(httpClient, apiKey)
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

	private async Task<TResponse> GetAsync<TRequest, TResponse>(
		TRequest request,
		CancellationToken cancellationToken
	) where TRequest : IncidentRequest
	{
		request.CommonParameters.ProxyDetails.APIKey = ApiKey;
		//var requestJson = JsonSerializer
		//	.Serialize(request);
		var response = await HttpClient
			.PostAsJsonAsync(string.Empty, request, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull }, cancellationToken);
		//var responseString = await response
		//	.Content
		//	.ReadAsStringAsync(cancellationToken);
		var returnValue = await response
			.Content
			.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {typeof(TResponse).Name}");
		return returnValue;
	}
}
