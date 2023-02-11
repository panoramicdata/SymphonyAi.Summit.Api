using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CreateOrUpdateIncidentRequestCommonParameters
{
	[JsonPropertyName("_ProxyDetails")]
	public ProxyDetails ProxyDetails { get; set; }

	[JsonPropertyName("incidentParamsJSON")]
	public CreateOrUpdateIncidentRequestIncidentParams IncidentParamsJson { get; set; }

	[JsonPropertyName("RequestType")]
	public string RequestType { get; set; } = "RemoteCall";
}
