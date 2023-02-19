using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbNetworkDetails
{
	[JsonPropertyName("ROOT")]
	public object Root { get; set; }
}
