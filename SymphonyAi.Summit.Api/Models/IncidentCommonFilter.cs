using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models;

[DataContract]
public class IncidentCommonFilter
{
	[DataMember(Name = "WorkgroupName")]
	public string WorkgroupName { get; set; } = string.Empty;

	[DataMember(Name = "CurrentPageIndex")]
	public int CurrentPageIndex { get; set; } = 1;

	[DataMember(Name = "PageSize")]
	public int PageSize { get; set; } = 100;

	[DataMember(Name = "OrgID")]
	public string OrgID { get; set; } = "1";

	[DataMember(Name = "Instance")]
	public string Instance { get; set; } = string.Empty;

	[DataMember(Name = "Status")]
	public string Status { get; set; } = string.Empty;

	[DataMember(Name = "strUpdatedFromDate")]
	public string UpdatedFromDate { get; set; } = DateTimeOffset.UtcNow.AddDays(-1).ToString("yyyy-MM-dd");

	[DataMember(Name = "strUpdatedToDate")]
	public string UpdatedToDate { get; set; } = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd");

	[DataMember(Name = "IsWebServiceRequest")]
	public bool IsWebServiceRequest { get; set; } = true;
}
