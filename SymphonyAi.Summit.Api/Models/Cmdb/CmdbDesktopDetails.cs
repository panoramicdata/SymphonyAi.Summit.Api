using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbDesktopDetails
{
	[JsonPropertyName("ROOT")]
	public object Root { get; set; }
}
