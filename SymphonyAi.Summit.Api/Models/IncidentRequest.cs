using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public abstract class IncidentRequest : Request
{
	public IncidentRequest(string incidentServiceName) : base("IM_" + incidentServiceName)
	{
	}

	[JsonPropertyName("objCommonParameters")]
	public IncidentCommonParameters CommonParameters { get; set; } = new();
}