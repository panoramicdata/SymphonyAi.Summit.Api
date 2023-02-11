using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CreateOrUpdateIncidentRequestIncidentContainerJsonObject
{
	[JsonPropertyName("Updater")]
	public string Updater { get; set; }

	[JsonPropertyName("CI_ID")]
	public string CiId { get; set; }

	[JsonPropertyName("CI_Key")]
	public string CiKey { get; set; }

	[JsonPropertyName("CI_Value")]
	public string CiValue { get; set; }

	[JsonPropertyName("Ticket")]
	public CreateOrUpdateIncidentRequestTicket Ticket { get; set; }

	[JsonPropertyName("TicketInformation")]
	public CreateOrUpdateIncidentRequestTicketInformation TicketInformation { get; set; }

	[JsonPropertyName("CustomFields")]
	public object[] CustomFields { get; set; }
}
