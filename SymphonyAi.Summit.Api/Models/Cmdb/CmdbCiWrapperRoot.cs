using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbCiWrapperRoot
{
	[JsonPropertyName("CMDBCIRelationsDetails")]
	public CmdbCiRelationsDetails RelationsDetails { get; set; } = new();

	[JsonPropertyName("CMDBDesktopDetails")]
	public CmdbDesktopDetails DesktopDetails { get; set; } = new();

	[JsonPropertyName("CMDBDetails")]
	public CmdbDetailsJustSubroot Details { get; set; } = new();

	[JsonPropertyName("CMDBNetworkDetails")]
	public CmdbNetworkDetails NetworkDetails { get; set; } = new();

	[JsonPropertyName("CMDBServerDetails")]
	public CmdbServerDetailsSubrootOnly ServerDetails { get; set; } = new();

	[JsonPropertyName("Relations")]
	public Relations Relations { get; set; } = new();
}
