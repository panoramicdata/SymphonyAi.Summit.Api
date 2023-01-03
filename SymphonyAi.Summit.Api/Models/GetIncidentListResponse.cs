using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class GetIncidentListResponse : Response
{
	[JsonPropertyName("OutputObject")]
	public required IncidentListOutputObject OutputObject { get; set; }
}
