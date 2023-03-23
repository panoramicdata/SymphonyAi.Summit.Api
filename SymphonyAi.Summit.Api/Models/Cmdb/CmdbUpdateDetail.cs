using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbUpdateDetail : CreateOrUpdateDetail
{
	[JsonPropertyName("Configuration_Id")]
	public string? ConfigurationItemId { get; set; }
}