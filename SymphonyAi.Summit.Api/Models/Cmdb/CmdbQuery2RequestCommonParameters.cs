using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbQuery2RequestCommonParameters
{
	[JsonPropertyName("AuthType")]
	public string AuthType { get; set; } = "APIKEY";

	[JsonPropertyName("APIKey")]
	public string ApiKey { get; set; } = "XXXXXX";

	[JsonPropertyName("ProxyID")]
	public int ProxyId { get; set; }

	[JsonPropertyName("OrgID")]
	public string OrgId { get; set; } = string.Empty;

	[JsonPropertyName("ReturnType")]
	public string ReturnType { get; set; } = "JSON";
}
