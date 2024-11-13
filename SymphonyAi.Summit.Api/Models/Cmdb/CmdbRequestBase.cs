using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public abstract class CmdbRequestBase(string name) : CmdbRequest(name)
{
	[JsonPropertyName("objCommonParameters")]
	public CmdbQueryRequestCommonParameters CommonParameters { get; set; } = new();
}
