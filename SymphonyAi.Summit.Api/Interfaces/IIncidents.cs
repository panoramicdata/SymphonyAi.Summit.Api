using SymphonyAi.Summit.Api.Models;

namespace SymphonyAi.Summit.Api.Interfaces;

/// <summary>
/// Incident interface
/// </summary>
public interface IIncidents
{
	/// <summary>
	/// Gets a summary list of incidents.
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<GetIncidentListResponse> GetIncidentListAsync(
		GetIncidentListRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a list of incidents, including details.
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<GetIncidentListResponse> GetIncidentListDetailsAsync(
		GetIncidentListDetailsRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets detailed information and change history for a single incident.
	/// </summary>
	/// <param name="request"></param>
	/// <param name="none"></param>
	/// <returns></returns>
	Task<GetIncidentDetailsAndChangeHistoryResponse> GetIncidentDetailsAndChangeHistoryAsync(
		GetIncidentDetailsAndChangeHistoryRequest request,
		CancellationToken none);
}
