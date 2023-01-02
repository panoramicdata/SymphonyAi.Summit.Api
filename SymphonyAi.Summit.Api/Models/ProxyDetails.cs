using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models;

[DataContract]
public class ProxyDetails
{
	[DataMember(Name = "AuthType")]
	public string AuthType { get; set; } = "APIKey";

	[DataMember(Name = "APIKey")]
	public string APIKey { get; set; } = string.Empty;

	[DataMember(Name = "ProxyID")]
	public int ProxyID { get; set; }

	[DataMember(Name = "ReturnType")]
	public string ReturnType { get; set; } = "json";

	[DataMember(Name = "OrgID")]
	public int OrgId { get; set; } = 1;

	[DataMember(Name = "TokenID")]
	public string TokenId { get; set; } = string.Empty;
}
