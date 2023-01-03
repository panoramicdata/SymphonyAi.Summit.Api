using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class IncidentCommonParameters
{
	[JsonPropertyName("_ProxyDetails")]
	public ProxyDetails ProxyDetails { get; set; } = new();

	[JsonPropertyName("objIncidentCommonFilter")]
	public IncidentCommonFilter? IncidentCommonFilter { get; set; }

	[JsonPropertyName("TicketNo")]
	public int? TicketNumber { get; set; }

	[JsonPropertyName("RequestType")]
	public string? RequestType { get; set; }
}
