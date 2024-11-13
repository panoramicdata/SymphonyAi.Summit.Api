using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbRelationshipQueryResponseModel
{
	[JsonPropertyName("TotalRecords")]
	public int TotalRecords { get; set; }

	[JsonPropertyName("CIRelations")]
	public List<CmdbRelationshipQueryResponseModelInner> CiRelations { get; set; } = [];
}
