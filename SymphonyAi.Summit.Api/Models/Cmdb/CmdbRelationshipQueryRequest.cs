using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbRelationshipQueryRequest : CmdbRequest
{
	public CmdbRelationshipQueryRequest() : base("GetCIRelationship")
	{
	}

	[JsonPropertyName("objCommonParameters")]
	public CmdbRelationshipQueryRequestCommonParameters CommonParameters { get; set; } = new();
}
