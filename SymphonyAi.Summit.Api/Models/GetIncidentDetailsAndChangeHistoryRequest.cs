namespace SymphonyAi.Summit.Api.Models;

public class GetIncidentDetailsAndChangeHistoryRequest : IncidentRequest<IncidentDetailsAndHistoryParameters>
{
	public GetIncidentDetailsAndChangeHistoryRequest() : base("GetIncidentDetailsAndChangeHistory")
	{
	}
}