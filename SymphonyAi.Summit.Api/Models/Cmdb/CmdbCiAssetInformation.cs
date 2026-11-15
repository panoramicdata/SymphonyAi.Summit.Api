using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public abstract class CmdbCiAssetInformation
{
	[JsonPropertyName("Rack")]
	public string Rack { get; set; } = string.Empty;

	[JsonPropertyName("Warranty")]
	public string Warranty { get; set; } = string.Empty;

	[JsonPropertyName("Annual_Maintains_Contract")]
	public string AnnualMaintenanceContract { get; set; } = string.Empty;

	[JsonPropertyName("Version")]
	public string Version { get; set; } = string.Empty;

	[JsonPropertyName("Description")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("Remarks")]
	public string Remarks { get; set; } = string.Empty;
}
