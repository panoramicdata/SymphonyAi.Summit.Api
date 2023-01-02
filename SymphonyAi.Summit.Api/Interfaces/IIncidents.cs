using SymphonyAi.Summit.Api.Models;

namespace SymphonyAi.Summit.Api.Interfaces;

public interface IIncidents
{
	Task<GetIncidentListResponse> GetIncidentListAsync(
		GetIncidentListRequest request,
		CancellationToken cancellationToken);
}
