using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting;

[DataContract]
public class TextValuePair
{
	[DataMember(Name = "text")]
	public string Text { get; set; } = string.Empty;

	[DataMember(Name = "value")]
	public string Value { get; set; } = string.Empty;
}
