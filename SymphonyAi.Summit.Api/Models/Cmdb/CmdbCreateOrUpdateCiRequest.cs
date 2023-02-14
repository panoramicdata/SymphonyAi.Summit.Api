using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbCreateOrUpdateCiRequest : CmdbRequest
{
	public CmdbCreateOrUpdateCiRequest() : base("CreateOrUpdateCIDetails")
	{
	}

	[JsonPropertyName("objCommonParameters")]
	public CmdbCreateOrUpdateCiRequestCommonParameters CommonParameters { get; set; } = new();
}
