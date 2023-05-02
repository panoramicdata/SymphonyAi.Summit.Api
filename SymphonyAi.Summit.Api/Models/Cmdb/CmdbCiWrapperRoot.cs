using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbCiWrapperRoot
{
	[JsonPropertyName("CMDBCIRelationsDetails")]
	public CmdbCiRelationsDetails RelationsDetails { get; set; } = new();

	[JsonPropertyName("CMDBDesktopDetails")]
	public CmdbDesktopDetails DesktopDetails { get; set; } = new();

	[JsonPropertyName("CMDBDetails")]
	public CmdbDetailsSubrootOnly Details { get; set; } = new();

	[JsonPropertyName("CMDBNetworkDetails")]
	public CmdbNetworkDetailsSubrootOnly NetworkDetails { get; set; } = new();

	[JsonPropertyName("CMDBServerDetails")]
	public CmdbServerDetailsSubrootOnly ServerDetails { get; set; } = new();

	[JsonPropertyName("Relations")]
	public Relations Relations { get; set; } = new();
}
