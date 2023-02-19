using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public abstract class CmdbRequestBase : CmdbRequest
{
	public CmdbRequestBase(string name) : base(name)
	{
	}

	[JsonPropertyName("objCommonParameters")]
	public CmdbQueryRequestCommonParameters CommonParameters { get; set; } = new();
}