using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbDetailWrapper
{
	[JsonPropertyName("CIDetail")]
	public List<CmdbDetail> Details { get; set; } = [];

	[JsonPropertyName("CustomAttribute")]
	public List<object?> CustomAttributes { get; set; } = [];

	[JsonPropertyName("MVCustomAttribute")]
	public List<object?> MvCustomAttributes { get; set; } = [];
}