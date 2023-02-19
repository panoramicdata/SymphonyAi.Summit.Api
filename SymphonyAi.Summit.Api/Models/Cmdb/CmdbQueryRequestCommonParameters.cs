using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbQueryRequestCommonParameters
{
	[JsonPropertyName("_ProxyDetails")]
	public ProxyDetails ProxyDetails { get; set; } = new();

	[JsonPropertyName("_CMDBDetails")]
	public CmdbRequestDetail CmdbDetails { get; set; } = new();
}