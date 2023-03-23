using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting;

[DataContract]
internal class ReportingRequestData
{
	[DataMember(Name = "DataSource")]
	public string DataSource { get; set; } = string.Empty;

	[DataMember(Name = "Columns")]
	public string Columns { get; set; } = string.Empty;

	[DataMember(Name = "Filters")]
	public string Filters { get; set; } = string.Empty;

	[DataMember(Name = "PageNumber")]
	public int PageNumber { get; set; } = 1;

	[DataMember(Name = "PageSize")]
	public string PageSize { get; set; } = "100";

	[DataMember(Name = "SortColumn")]
	public string SortColumn { get; set; } = string.Empty;

	[DataMember(Name = "SortOrder")]
	public string SortOrder { get; set; } = "ASC";

	[DataMember(Name = "RawSQL")]
	public string RawSQL { get; set; } = string.Empty;
}
