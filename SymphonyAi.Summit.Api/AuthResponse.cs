using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api;

internal class AuthResponse
{
	[JsonPropertyName("Token")]
	public string Token { get; set; } = string.Empty;

	[JsonPropertyName("Expire_InSecs")]
	public int ExpireInSecs { get; set; }

	public DateTimeOffset ExpiresAt { get; set; } = DateTimeOffset.MinValue;
}
