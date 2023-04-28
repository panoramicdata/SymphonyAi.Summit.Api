using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbRelationshipQueryResponseModelInner
{
	[JsonPropertyName("ID")]
	public int Id { get; set; }

	[JsonPropertyName("RelationshipType")]
	public string RelationshipType { get; set; } = string.Empty;

	[JsonPropertyName("Classification")]
	public string Classification { get; set; } = string.Empty;

	[JsonPropertyName("ServiceName")]
	public string ServiceName { get; set; } = string.Empty;

	[JsonPropertyName("Criticality")]
	public string Criticality { get; set; } = string.Empty;

	[JsonPropertyName("Device_HostName")]
	public string DeviceHostName { get; set; } = string.Empty;

	[JsonPropertyName("Serial_No")]
	public string SerialNumber { get; set; } = string.Empty;

	[JsonPropertyName("IPAddress")]
	public string IpAddress { get; set; } = string.Empty;

	[JsonPropertyName("MAC_Address")]
	public string MacAddress { get; set; } = string.Empty;

	[JsonPropertyName("Location")]
	public string Location { get; set; } = string.Empty;
}
