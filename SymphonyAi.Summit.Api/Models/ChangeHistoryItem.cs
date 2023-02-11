using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class ChangeHistoryItem
{
	[JsonPropertyName("uid")]
	public int Id { get; set; }

	[JsonPropertyName("column_name")]
	public /*required*/ string ColumnName { get; set; }

	[JsonPropertyName("change_date")]
	public /*required*/ string ChangeDate { get; set; }

	[JsonPropertyName("change_by")]
	public /*required*/ int ChangeById { get; set; }

	[JsonPropertyName("change_byName")]
	public /*required*/ string ChangeByName { get; set; }

	[JsonPropertyName("OldValue")]
	public string? OldValue { get; set; }

	[JsonPropertyName("new_Value")]
	public /*required*/ string NewValue { get; set; }

	[JsonPropertyName("AttributeType")]
	public /*required*/ string AttributeType { get; set; }
}
