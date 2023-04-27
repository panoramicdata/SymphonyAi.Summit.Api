using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting;

[DataContract]
public class Status
{
	[DataMember(Name = "message")]
	public string Message { get; set; } = string.Empty;

	[DataMember(Name = "status")]
	public string Value { get; set; } = string.Empty;

	[DataMember(Name = "isValid")]
	public bool IsValid { get; set; }
}