using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models;

[DataContract]
public class CommonParameters
{
	[DataMember(Name = "_ProxyDetails")]
	public ProxyDetails ProxyDetails { get; set; } = new();

	[DataMember(Name = "objIncidentCommonFilter")]
	public IncidentCommonFilter IncidentCommonFilter { get; set; } = new();
}
