using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class Ticket
{
	[JsonPropertyName("IncidentDetail")]
	public /*required*/ List<IncidentDetail> IncidentDetail { get; set; }

	[JsonPropertyName("CustomAttribute")]
	public /*required*/ List<CustomAttribute> CustomAttribute { get; set; } = new();
}
