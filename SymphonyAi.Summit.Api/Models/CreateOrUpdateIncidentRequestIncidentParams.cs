using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CreateOrUpdateIncidentRequestIncidentParams
{
	[JsonPropertyName("IncidentContainerJsonObj")]
	public CreateOrUpdateIncidentRequestIncidentContainerJsonObject IncidentContainerJsonObj { get; } = new();
}
