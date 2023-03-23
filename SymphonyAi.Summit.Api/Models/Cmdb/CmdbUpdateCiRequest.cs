using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbUpdateCiRequest : CmdbRequest
{
	public CmdbUpdateCiRequest() : base("CreateOrUpdateCIDetails")
	{
	}

	[JsonPropertyName("objCommonParameters")]
	public CmdbUpdateCiRequestCommonParameters CommonParameters { get; set; } = new();
}
