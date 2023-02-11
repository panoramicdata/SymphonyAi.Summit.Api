using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CreateOrUpdateIncidentRequestTicketInformation
{
	[JsonPropertyName("Information")]
	public string Information { get; set; } = string.Empty;

	[JsonPropertyName("InternalLog")]
	public string InternalLog { get; set; } = string.Empty;

	[JsonPropertyName("UserLog")]
	public string UserLog { get; set; } = string.Empty;
}
