using System.Diagnostics;
using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

[DebuggerDisplay("{LabelName}")]
public class GridViewDisplayColumn
{

	[JsonPropertyName("LabelName")]
	public required string LabelName { get; set; }

	[JsonPropertyName("Value")]
	public required string Value { get; set; }

	[JsonPropertyName("Placeholder")]
	public required object Placeholder { get; set; }

	[JsonPropertyName("IsCustomField")]
	public bool IsCustomField { get; set; }
}
