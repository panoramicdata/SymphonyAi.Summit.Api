using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting;

[DataContract]
public class PaginationDetails
{
	[DataMember(Name = "page_size")]
	public int PageSize { get; set; }

	[DataMember(Name = "prev_offset")]
	public int PreviousOffset { get; set; }

	[DataMember(Name = "current_offset")]
	public int CurrentOffset { get; set; }

	[DataMember(Name = "next_offset")]
	public int NextOffset { get; set; }

	[DataMember(Name = "prev_page")]
	public int PreviousPageNumber { get; set; }

	[DataMember(Name = "current_page")]
	public int CurrentPageNumber { get; set; }

	[DataMember(Name = "next_page")]
	public int NextPageNumber { get; set; }

	[DataMember(Name = "total_pages")]
	public int TotalPages { get; set; }

	[DataMember(Name = "total_items")]
	public int TotalItems { get; set; }

	[DataMember(Name = "prev_page_url")]
	public string? PreviousPageUrl { get; set; }

	[DataMember(Name = "current_page_url")]
	public string? CurrentPageUrl { get; set; }

	[DataMember(Name = "next_page_url")]
	public string? NextPageUrl { get; set; }
}

