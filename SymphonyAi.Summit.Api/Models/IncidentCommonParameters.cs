using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class IncidentCommonParameters : CommonParametersBase
{
	[JsonPropertyName("objIncidentCommonFilter")]
	public IncidentCommonFilter? IncidentCommonFilter { get; set; }
}
