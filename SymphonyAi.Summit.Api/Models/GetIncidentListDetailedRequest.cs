namespace SymphonyAi.Summit.Api.Models;

public class GetIncidentListDetailsRequest : IncidentRequest<IncidentCommonParameters>
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
