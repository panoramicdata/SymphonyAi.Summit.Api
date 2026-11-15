using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbRelationshipDetails : CmdbRelationshipDeviceBase
{
	[JsonPropertyName("InstanceName")]
	public string InstanceName { get; set; } = string.Empty;

	[JsonPropertyName("Configuration_Id")]
	public string ConfigurationId { get; set; } = string.Empty;

	[JsonPropertyName("Device_Host_Name")]
	public string DeviceHostName { get; set; } = string.Empty;

	[JsonPropertyName("CurrentPageIndex")]
	public int CurrentPageIndex { get; set; }

	[JsonPropertyName("PageSize")]
	public int PageSize { get; set; }
}