using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbQueryRequestDetails
{
	[JsonPropertyName("InstanceName")]
	public string InstanceName { get; set; } = string.Empty;

	[JsonPropertyName("Classification")]
	public string Classification { get; set; } = string.Empty;

	[JsonPropertyName("IsIncludeInactive")]
	public string? IsIncludeInactive { get; set; }

	[JsonPropertyName("CurrentPageIndex")]
	public int CurrentPageIndex { get; set; }

	[JsonPropertyName("PageSize")]
	public int PageSize { get; set; } = 100;
}
