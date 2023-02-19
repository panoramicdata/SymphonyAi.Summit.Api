using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbServerDetailsSubrootOnly
{
	[JsonPropertyName("SUBROOT")]
	public CmdbServerDetailsSubroot Subroot { get; set; } = new();
}
