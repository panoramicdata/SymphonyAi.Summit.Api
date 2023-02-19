using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbCiRequest : CmdbRequestBase
{
	public CmdbCiRequest() : base("GetCIDetails")
	{
	}

	[JsonPropertyName("bIncDeActive")]
	public bool IncludeInactive { get; set; } = true;
}
