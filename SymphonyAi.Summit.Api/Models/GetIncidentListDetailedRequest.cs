namespace SymphonyAi.Summit.Api.Models;

public class GetIncidentListDetailsRequest : IncidentQueryRequest
{
	public GetIncidentListDetailsRequest() : base("GetIncidentListwithDetails")
	{
		CommonParameters.IncidentCommonFilter = new()
		{
			CategoryName = string.Empty,
			Categories = string.Empty
		};
	}
}
