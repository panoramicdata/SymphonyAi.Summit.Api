using Newtonsoft.Json;

namespace SymphonyAi.Summit.Api.Test.Models
{
	public class GetIncidentIdsBySymptomResponseData
	{
		[JsonProperty("Ticket_ID")]
		public int TicketId { get; set; }

		[JsonProperty("Ticket_No")]
		public string? TicketNumber { get; set; }
	}
}