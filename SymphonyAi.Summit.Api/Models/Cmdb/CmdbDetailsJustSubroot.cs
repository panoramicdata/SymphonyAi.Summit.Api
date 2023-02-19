using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbDetailsJustSubroot
{
	[JsonPropertyName("SUBROOT")]
	public CmdbDetailsSubroot Subroot { get; set; }
}
