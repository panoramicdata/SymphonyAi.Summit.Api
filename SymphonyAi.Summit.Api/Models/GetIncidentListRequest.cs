namespace SymphonyAi.Summit.Api.Models;

public class GetIncidentListRequest : IncidentRequest<IncidentCommonParameters>
{
	public GetIncidentListRequest() : base("GetIncidentList")
	{
	}
}
