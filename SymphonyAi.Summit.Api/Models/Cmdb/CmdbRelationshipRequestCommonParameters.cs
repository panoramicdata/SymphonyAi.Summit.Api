using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbRelationshipRequestCommonParameters
{
	[JsonPropertyName("_ProxyDetails")]
	public ProxyDetails ProxyDetails { get; set; } = new();


	[JsonPropertyName("_CMDBCIRelations")]
	public CmdbRelationship Relation { get; } = new();
}