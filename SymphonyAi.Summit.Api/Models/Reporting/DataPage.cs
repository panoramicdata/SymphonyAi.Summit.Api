using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting;

[DataContract]
public class DataPage
{
	[DataMember(Name = "pagination")]
	public Pagination Pagination { get; set; } = new();

	[DataMember(Name = "results")]
	public ICollection<object> Results { get; set; } = [];

	[DataMember(Name = "Status")]
	public Status Status { get; set; } = new();
}
