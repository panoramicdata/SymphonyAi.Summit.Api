using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting.Incidents;

public class IncidentSummary
{
	[JsonPropertyName("Incident_ID")]
	public int IncidentId { get; set; }

	[JsonPropertyName("Description")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("Status")]
	public string Status { get; set; } = string.Empty;
}
