using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbCreateCiRequest : CmdbRequest
{
	public CmdbCreateCiRequest() : base("CreateOrUpdateCIDetails")
	{
	}

	[JsonPropertyName("objCommonParameters")]
	public CmdbCreateCiRequestCommonParameters CommonParameters { get; set; } = new();
}
