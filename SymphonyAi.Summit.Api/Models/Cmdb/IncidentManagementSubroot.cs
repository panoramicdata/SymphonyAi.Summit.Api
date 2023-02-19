using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class IncidentManagementSubroot
{

	[JsonPropertyName("Caller_Name")]
	public string CallerName { get; set; }

	[JsonPropertyName("Org_Id")]
	public string OrgId { get; set; }

	[JsonPropertyName("Reg_Time")]
	public DateTime RegTime { get; set; }

	[JsonPropertyName("Severity_Display")]
	public string SeverityDisplay { get; set; }

	[JsonPropertyName("Severity_Name")]
	public string SeverityName { get; set; }

	[JsonPropertyName("Source_Type")]
	public string SourceType { get; set; }

	[JsonPropertyName("Status")]
	public string Status { get; set; }

	[JsonPropertyName("Ticket_ID")]
	public string TicketId { get; set; }

	[JsonPropertyName("Ticket_No")]
	public string TicketNumber { get; set; }

	[JsonPropertyName("Workorder_ID")]
	public string WorkOrderId { get; set; }
}
