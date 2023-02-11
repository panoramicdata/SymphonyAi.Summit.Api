using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class IncidentDetails
{

	[JsonPropertyName("TicketDetails")]
	public /*required*/ List<IncidentDetail2> TicketDetails { get; set; }

	[JsonPropertyName("ChangeHistory")]
	public /*required*/ List<ChangeHistoryItem> ChangeHistory { get; set; }

	[JsonPropertyName("CustomAttributes")]
	public /*required*/ List<CustomAttribute> CustomAttributes { get; set; }
}
