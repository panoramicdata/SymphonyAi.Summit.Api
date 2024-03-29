﻿using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class ProxyDetails
{
	[JsonPropertyName("AuthType")]
	public string AuthType { get; set; } = "APIKEY";

	[JsonPropertyName("APIKey")]
	public string ApiKey { get; set; } = string.Empty;

	[JsonPropertyName("ProxyID")]
	public int ProxyID { get; set; }

	[JsonPropertyName("ReturnType")]
	public string ReturnType { get; set; } = "JSON";

	[JsonPropertyName("OrgID")]
	public int? OrgId { get; set; } = 1;

	[JsonPropertyName("TokenID")]
	public string? TokenId { get; set; }
}
