using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public abstract class Response
{
	[JsonPropertyName("Errors")]
	public /*required*/ string Errors { get; set; }

	[JsonPropertyName("Message")]
	public /*required*/ string Message { get; set; }

	[JsonPropertyName("Output")]
	public string? Output { get; set; }

	[JsonPropertyName("TokenID")]
	public string? TokenId { get; set; }

	[JsonPropertyName("OrgID")]
	public int OrgId { get; set; }

	[JsonPropertyName("OutputID")]
	public int OutputId { get; set; }

	[JsonPropertyName("Input")]
	public /*required*/ object Input { get; set; }
}
