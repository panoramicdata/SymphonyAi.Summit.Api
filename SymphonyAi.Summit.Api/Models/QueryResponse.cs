using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public abstract class QueryResponse<T>
{
	[JsonPropertyName("Errors")]
	public string Errors { get; set; } = string.Empty;

	[JsonPropertyName("Message")]
	public string Message { get; set; } = string.Empty;

	[JsonPropertyName("Output")]
	public string Output { get; set; } = string.Empty;

	[JsonPropertyName("TokenID")]
	public object? TokenId { get; set; }

	[JsonPropertyName("OrgID")]
	public int? OrgId { get; set; }

	[JsonPropertyName("OutputID")]
	public int? OutputId { get; set; }

	[JsonPropertyName("Input")]
	public object? Input { get; set; }

	[JsonPropertyName("OutputObject")]
	public List<T> OutputObjects { get; set; } = new();
}