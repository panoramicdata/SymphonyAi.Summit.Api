using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CreateOrUpdateIncidentRequestCommonParameters
{
	[JsonPropertyName("_ProxyDetails")]
	public ProxyDetails ProxyDetails { get; set; } = new();

	[JsonPropertyName("incidentParamsJSON")]
	public CreateOrUpdateIncidentRequestIncidentParams IncidentParamsJson { get; set; } = new();

	[JsonPropertyName("RequestType")]
	public string RequestType { get; set; } = "RemoteCall";
}
