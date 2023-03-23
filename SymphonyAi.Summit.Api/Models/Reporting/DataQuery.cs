using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Reporting;

[DataContract]
public class DataQuery
{
	[DataMember(Name = "DataSource")]
	public string Table { get; set; } = string.Empty;

	[DataMember(Name = "Columns")]
	public string Columns { get; set; } = string.Empty;

	[DataMember(Name = "Filters")]
	public string Filters { get; set; } = string.Empty;

	[DataMember(Name = "PageNumber")]
	public int PageNumber { get; set; } = 1;

	[DataMember(Name = "PageSize")]
	public string PageSize { get; set; } = "10000";

	[DataMember(Name = "SortColumn")]
	public string SortColumn { get; set; } = string.Empty;

	[DataMember(Name = "SortOrder")]
	public string SortOrder { get; set; } = "ASC";

	[DataMember(Name = "RawSQL")]
	public string RawSql { get; set; } = string.Empty;
}