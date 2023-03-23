using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbCreateDetail : CreateOrUpdateDetail
{
	[JsonPropertyName("Configuration_Item_Id")]
	public string? ConfigurationItemId { get; set; }
}
