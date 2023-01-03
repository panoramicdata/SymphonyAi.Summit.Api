namespace SymphonyAi.Summit.Api.Models;

public abstract class IncidentQueryRequest : IncidentRequest
{
	public IncidentQueryRequest(string incidentServiceName) : base(incidentServiceName)
	{
	}
}