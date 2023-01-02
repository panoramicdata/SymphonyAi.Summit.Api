using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models;

[DataContract]
public class GetIncidentListRequest
{
	[DataMember(Name = "ServiceName")]
	public string ServiceName { get; } = "IM_GetIncidentList";

	[DataMember(Name = "objCommonParameters")]
	public CommonParameters CommonParameters { get; set; } = new();
}