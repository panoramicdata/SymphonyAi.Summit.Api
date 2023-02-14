using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbQueryRequest : CmdbRequest
{
	public CmdbQueryRequest() : base("Query")
	{
	}

	[JsonPropertyName("objCommonParameters")]
	public CmdbQueryRequestCommonParameters CommonParameters { get; set; } = new();

	[JsonPropertyName("_CMDBDetails")]
	public CmdbQueryRequestDetails Details { get; set; } = new();
}
