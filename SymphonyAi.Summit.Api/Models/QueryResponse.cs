using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public abstract class QueryResponse<T> where T : new()
{
	[JsonPropertyName("Errors")]
	public string Errors { get; set; } = string.Empty;

	[JsonPropertyName("Message")]
	public string Message { get; set; } = string.Empty;

	[JsonPropertyName("Output")]
	public string Output { get; set; } = string.Empty;

	[JsonPropertyName("TokenID")]
	public string? TokenId { get; set; }

	[JsonPropertyName("OrgID")]
	public int? OrgId { get; set; }

	[JsonPropertyName("OutputID")]
	public int? OutputId { get; set; }

	[JsonPropertyName("Input")]
	public object? Input { get; set; }

	[JsonPropertyName("OutputObject")]
	public T OutputObject { get; set; } = new();
}