using SymphonyAi.Summit.Api.Exceptions;
using SymphonyAi.Summit.Api.Interfaces;
using SymphonyAi.Summit.Api.Models;
using System.Net.Http.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class IncidentManager : Manager, IIncidents
{
	public IncidentManager(HttpClient httpClient, string apiKey)
		: base(httpClient, apiKey)
	{
	}

	public async Task<GetIncidentListResponse> GetIncidentListAsync(
		GetIncidentListRequest request,
		CancellationToken cancellationToken
	)
	{
		request.CommonParameters.ProxyDetails.APIKey = ApiKey;
		var response = await HttpClient.PostAsJsonAsync(string.Empty, request, cancellationToken);
		var returnValue = await response.Content.ReadFromJsonAsync<GetIncidentListResponse>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {nameof(GetIncidentListResponse)}");
		return returnValue;
	}
}
