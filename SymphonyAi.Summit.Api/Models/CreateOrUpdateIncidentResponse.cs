using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CreateOrUpdateIncidentResponse : Response
{
	[JsonPropertyName("OrgID")]
	public int OrgId { get; set; }

	[JsonPropertyName("OutputID")]
	public int OutputId { get; set; }

	[JsonPropertyName("OutputObject")]
	public object OutputObject { get; set; }

	[JsonPropertyName("TokenID")]
	public object TokenId { get; set; }

	[JsonPropertyName("Priority")]
	public object Priority { get; set; }

	[JsonPropertyName("ResolutionDeadLine")]
	public object ResolutionDeadline { get; set; }

	[JsonPropertyName("Resolution_DeadLine")]
	public string Resolution_Deadline { get; set; }

	[JsonPropertyName("SLA")]
	public object Sla { get; set; }

	[JsonPropertyName("TicketID_Encrypted")]
	public string EncryptedTicketId { get; set; }

	[JsonPropertyName("TicketID_Internal")]
	public int InternalTicketId { get; set; }

	[JsonPropertyName("TicketNo")]
	public int TicketNumber { get; set; }
}