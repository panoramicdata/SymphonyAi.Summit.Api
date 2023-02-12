using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CreateOrUpdateIncidentRequestCommonParameters
{
	[JsonPropertyName("_ProxyDetails")]
	public ProxyDetails ProxyDetails { get; } = new();

	[JsonPropertyName("incidentParamsJSON")]
	public CreateOrUpdateIncidentRequestIncidentParams IncidentParamsJson { get; } = new();

	[JsonPropertyName("RequestType")]
	public string RequestType { get; set; } = "RemoteCall";
}
