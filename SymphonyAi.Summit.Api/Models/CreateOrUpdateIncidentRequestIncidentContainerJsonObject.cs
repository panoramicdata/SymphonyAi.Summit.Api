using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CreateOrUpdateIncidentRequestIncidentContainerJsonObject
{
	[JsonPropertyName("Updater")]
	public string Updater { get; set; } = string.Empty;

	[JsonPropertyName("CI_ID")]
	public string CiId { get; set; } = string.Empty;

	[JsonPropertyName("CI_Key")]
	public string CiKey { get; set; } = string.Empty;

	[JsonPropertyName("CI_Value")]
	public string CiValue { get; set; } = string.Empty;

	[JsonPropertyName("Ticket")]
	public CreateOrUpdateIncidentRequestTicket Ticket { get; set; } = new();

	[JsonPropertyName("TicketInformation")]
	public CreateOrUpdateIncidentRequestTicketInformation TicketInformation { get; set; } = new();

	[JsonPropertyName("CustomFields")]
	public List<object> CustomFields { get; set; } = [];
}
