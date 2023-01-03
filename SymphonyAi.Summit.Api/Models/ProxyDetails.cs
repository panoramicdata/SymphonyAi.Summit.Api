using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class ProxyDetails
{
	[JsonPropertyName("AuthType")]
	public string AuthType { get; set; } = "APIKey";

	[JsonPropertyName("APIKey")]
	public string APIKey { get; set; } = string.Empty;

	[JsonPropertyName("ProxyID")]
	public int ProxyID { get; set; }

	[JsonPropertyName("ReturnType")]
	public string ReturnType { get; set; } = "json";

	[JsonPropertyName("OrgID")]
	public int OrgId { get; set; } = 1;

	[JsonPropertyName("TokenID")]
	public string TokenId { get; set; } = string.Empty;
}
