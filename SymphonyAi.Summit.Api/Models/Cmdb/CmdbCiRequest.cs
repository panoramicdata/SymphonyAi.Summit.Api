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
