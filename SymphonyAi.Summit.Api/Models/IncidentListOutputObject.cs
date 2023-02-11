using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class IncidentListOutputObject
{

	[JsonPropertyName("MyTickets")]
	public /*required*/ List<Ticket> MyTickets { get; set; }

	[JsonPropertyName("GridViewDisplayColumns")]
	public List<GridViewDisplayColumn>? GridViewDisplayColumns { get; set; }
}
