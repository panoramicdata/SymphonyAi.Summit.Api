using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;
public class CreateOrUpdateIncidentResponse
{
	[JsonPropertyName("ServiceName")]
	public /*required*/ string ServiceName { get; set; }

	[JsonPropertyName("objCommonParameters")]
	public /*required*/ CreateOrUpdateIncidentResponseCommonParameters CommonParameters { get; set; }
}

public class CreateOrUpdateIncidentResponseCommonParameters
{
	[JsonPropertyName("_ProxyDetails")]
	public /*required*/ ProxyDetails ProxyDetails { get; set; }

	[JsonPropertyName("incidentParamsJSON")]
	public /*required*/ IncidentParamsJson IncidentParamsJson { get; set; }

	[JsonPropertyName("RequestType")]
	public /*required*/ string RequestType { get; set; }
}

public class IncidentParamsJson
{
	[JsonPropertyName("IncidentContainerJson")]
	public string IncidentContainerJson { get; set; }
}
