using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class IncidentDetailsAndHistoryParameters : CommonParametersBase
{
	[JsonPropertyName("TicketNo")]
	public int? TicketNumber { get; set; }

	[JsonPropertyName("RequestType")]
	public string? RequestType { get; set; }
}
