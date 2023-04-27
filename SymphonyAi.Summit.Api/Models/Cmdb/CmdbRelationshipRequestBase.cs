using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public abstract class CmdbRelationshipRequestBase : CmdbRequest
{
	public CmdbRelationshipRequestBase(string name) : base(name)
	{
	}

	[JsonPropertyName("objCommonParameters")]
	public CmdbRelationshipRequestCommonParameters CommonParameters { get; set; } = new();

	[JsonPropertyName("_CMDBCIRelations")]
	public CmdbRelationship Relation { get; } = new();
}