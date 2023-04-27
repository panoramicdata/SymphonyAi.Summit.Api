using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbCustomersRequest : CmdbRequestBase
{
	public CmdbCustomersRequest() : base("GetCustomerMasterList")
	{
	}

	[JsonPropertyName("strInstance")]
	public string InstanceName { get; set; } = string.Empty;

	[JsonPropertyName("bIncDeActive")]
	public bool IncludeInactive { get; set; } = true;
}
