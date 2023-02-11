using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class IncidentDetailsAndChangeHistoryOutputObject
{
	[JsonPropertyName("IncidentDetails")]
	public /*required*/ IncidentDetails IncidentDetails { get; set; }
}
