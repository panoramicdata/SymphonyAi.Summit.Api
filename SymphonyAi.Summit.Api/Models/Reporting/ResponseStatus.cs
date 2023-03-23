using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting;

[DataContract]
public class ResponseStatus
{
	[DataMember(Name = "message")]
	public string Message { get; set; } = string.Empty;

	[DataMember(Name = "status")]
	public string Status { get; set; } = string.Empty;

	[DataMember(Name = "isValid")]
	public bool IsValid { get; set; }
}

