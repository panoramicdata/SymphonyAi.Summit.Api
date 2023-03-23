using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting;

[DataContract]
public class ReportingResponse<T> where T : class
{
	[DataMember(Name = "pagination")]
	public PaginationDetails PaginationDetails { get; set; } = new();

	[DataMember(Name = "results")]
	public List<T> Incident { get; set; } = new();

	[DataMember(Name = "Status")]
	public ResponseStatus Status { get; set; } = new();
}
