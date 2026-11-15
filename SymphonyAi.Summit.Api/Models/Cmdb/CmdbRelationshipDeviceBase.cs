using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public abstract class CmdbRelationshipDeviceBase
{
	[JsonPropertyName("Serial_No")]
	public string SerialNumber { get; set; } = string.Empty;

	[JsonPropertyName("IPAddress")]
	public string IpAddress { get; set; } = string.Empty;
}
