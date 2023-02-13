using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CreateOrUpdateIncidentRequest : Request
{
	public CreateOrUpdateIncidentRequest() : base("IM_LogOrUpdateIncident")
	{
	}

	[JsonPropertyName("objCommonParameters")]
	public CreateOrUpdateIncidentRequestCommonParameters CommonParameters { get; set; } = new();
}