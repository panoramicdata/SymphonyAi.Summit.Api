using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CreateOrUpdateIncidentRequestTicket
{
	[JsonPropertyName("IsFromWebService")]
	public bool IsFromWebService { get; set; }

	[JsonPropertyName("Ticket_No")]
	public string? TicketNumber { get; set; }

	[JsonPropertyName("Priority_Name")]
	public /*required*/ string PriorityName { get; set; }

	[JsonPropertyName("Classification_Name")]
	public /*required*/ string ClassificationName { get; set; }

	[JsonPropertyName("Sup_Function")]
	public /*required*/ string SupFunction { get; set; }

	[JsonPropertyName("Caller_EmailID")]
	public /*required*/ string CallerEmailId { get; set; }

	[JsonPropertyName("Status")]
	public /*required*/ string Status { get; set; }

	[JsonPropertyName("Urgency_Name")]
	public /*required*/ string UrgencyName { get; set; }

	[JsonPropertyName("Assigned_WorkGroup_Name")]
	public /*required*/ string AssignedWorkGroupName { get; set; }

	[JsonPropertyName("Medium")]
	public /*required*/ string Medium { get; set; }

	[JsonPropertyName("Impact_Name")]
	public /*required*/ string ImpactName { get; set; }

	[JsonPropertyName("Category_Name")]
	public /*required*/ string CategoryName { get; set; }

	[JsonPropertyName("SLA_Name")]
	public /*required*/ string SlaName { get; set; }

	[JsonPropertyName("OpenCategory_Name")]
	public /*required*/ string OpenCategoryName { get; set; }

	[JsonPropertyName("Source")]
	public string Source { get; set; } = string.Empty;

	[JsonPropertyName("Assigned_Engineer_Email")]
	public /*required*/ string AssignedEngineerEmail { get; set; }

	[JsonPropertyName("Description")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("PageName")]
	public string PageName { get; set; } = "TicketDetail";

	[JsonPropertyName("Mail_CC_EmailID")]
	public string? MailCcEmailId { get; set; } = null;
}
