using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting;

public class Pagination
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
	public int PreviousPage { get; set; }

	[DataMember(Name = "current_page")]
	public int CurrentPage { get; set; }

	[DataMember(Name = "next_page")]
	public int NextPage { get; set; }

	[DataMember(Name = "total_pages")]
	public int TotalPageCount { get; set; }

	[DataMember(Name = "total_items")]
	public int TotalItemCount { get; set; }

	[DataMember(Name = "prev_page_url")]
	public object PreviousPageUrl { get; set; }

	[DataMember(Name = "current_page_url")]
	public object CurrentPageUrl { get; set; }

	[DataMember(Name = "next_page_url")]
	public object NextPageUrl { get; set; }
}
