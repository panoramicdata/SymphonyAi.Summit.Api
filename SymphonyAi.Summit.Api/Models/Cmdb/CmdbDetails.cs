using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbDetails
{
	[JsonPropertyName("CIDetails")]
	public List<CmdbDetailWrapper> Details { get; set; } = new();
}