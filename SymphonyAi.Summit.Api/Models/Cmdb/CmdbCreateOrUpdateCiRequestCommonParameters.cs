using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbCreateOrUpdateCiRequestCommonParameters
{
	[JsonPropertyName("_ProxyDetails")]
	public ProxyDetails ProxyDetails { get; set; } = new();

	[JsonPropertyName("_CMDBDetails")]
	public CmdbDetails CmdbDetails { get; set; } = new();
}
