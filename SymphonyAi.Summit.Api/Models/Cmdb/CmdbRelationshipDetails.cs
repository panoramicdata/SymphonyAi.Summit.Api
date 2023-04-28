namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbRelationshipDetails
{
	public string InstanceName { get; set; } = string.Empty;
	public string Configuration_Id { get; set; } = string.Empty;
	public string Device_Host_Name { get; set; } = string.Empty;
	public string Serial_No { get; set; } = string.Empty;
	public string IPAddress { get; set; } = string.Empty;
	public int CurrentPageIndex { get; set; }
	public int PageSize { get; set; }
}