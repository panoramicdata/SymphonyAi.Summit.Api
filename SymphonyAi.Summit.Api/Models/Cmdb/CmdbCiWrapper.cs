using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbCiWrapper
{
	[JsonPropertyName("ROOT")]
	public CmdbCiWrapperRoot Root { get; set; }
}
