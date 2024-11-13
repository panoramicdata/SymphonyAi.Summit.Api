using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public abstract class CmdbRelationshipRequestBase(string name) : CmdbRequest(name)
{
	[JsonPropertyName("objCommonParameters")]
	public CmdbRelationshipRequestCommonParameters CommonParameters { get; set; } = new();
}