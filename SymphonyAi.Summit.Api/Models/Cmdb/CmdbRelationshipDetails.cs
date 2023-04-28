using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbRelationshipDetails
{
	[JsonPropertyName("InstanceName")]
	public string InstanceName { get; set; } = string.Empty;

	[JsonPropertyName("Configuration_Id")]
	public string ConfigurationId { get; set; } = string.Empty;

	[JsonPropertyName("Device_Host_Name")]
	public string DeviceHostName { get; set; } = string.Empty;

	[JsonPropertyName("Serial_No")]
	public string SerialNumber { get; set; } = string.Empty;

	[JsonPropertyName("IPAddress")]
	public string IpAddress { get; set; } = string.Empty;

	[JsonPropertyName("CurrentPageIndex")]
	public int CurrentPageIndex { get; set; }

	[JsonPropertyName("PageSize")]
	public int PageSize { get; set; }
}