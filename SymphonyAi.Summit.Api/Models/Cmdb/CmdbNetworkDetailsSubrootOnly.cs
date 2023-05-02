using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbNetworkDetailsSubrootOnly
{
	[JsonPropertyName("SUBROOT")]
	public CmdbNetworkDetailsSubroot Subroot { get; set; } = new();
}
