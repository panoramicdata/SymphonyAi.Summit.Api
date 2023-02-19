using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbDetails
{
	[JsonPropertyName("CIDetails")]
	public List<CmdbDetail> Details { get; set; } = new();
}