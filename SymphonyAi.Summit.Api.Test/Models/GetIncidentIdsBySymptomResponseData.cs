using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Test.Models
{
	public class GetIncidentIdsBySymptomResponseData
	{
		[JsonPropertyName("Ticket_ID")]
		public int TicketId { get; set; }

		[JsonPropertyName("Ticket_No")]
		public string? TicketNumber { get; set; }
	}
}