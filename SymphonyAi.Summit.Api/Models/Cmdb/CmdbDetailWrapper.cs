using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbDetailWrapper
{
	[JsonPropertyName("CIDetail")]
	public List<CmdbDetail> Details { get; set; } = new();

	[JsonPropertyName("CustomAttribute")]
	public List<object?> CustomAttributes { get; set; } = new();

	[JsonPropertyName("MVCustomAttribute")]
	public List<object?> MvCustomAttributes { get; set; } = new();
}