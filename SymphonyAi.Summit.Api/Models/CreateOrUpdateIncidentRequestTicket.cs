using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CreateOrUpdateIncidentRequestTicket
{
	[JsonPropertyName("IsFromWebService")]
	public bool IsFromWebService { get; set; }

	[JsonPropertyName("Ticket_No")]
	public string? TicketNumber { get; set; }

	[JsonPropertyName("Priority_Name")]
	public string PriorityName { get; set; } = string.Empty;

	[JsonPropertyName("Classification_Name")]
	public string ClassificationName { get; set; } = string.Empty;

	[JsonPropertyName("Sup_Function")]
	public string SupFunction { get; set; } = string.Empty;

	[JsonPropertyName("Caller_EmailID")]
	public string CallerEmailId { get; set; } = string.Empty;

	[JsonPropertyName("Status")]
	public string Status { get; set; } = "New";

	[JsonPropertyName("Urgency_Name")]
	public string UrgencyName { get; set; } = string.Empty;

	[JsonPropertyName("Assigned_WorkGroup_Name")]
	public string AssignedWorkGroupName { get; set; } = string.Empty;

	[JsonPropertyName("Medium")]
	public string Medium { get; set; } = string.Empty;

	[JsonPropertyName("Impact_Name")]
	public string ImpactName { get; set; } = string.Empty;

	[JsonPropertyName("Category_Name")]
	public string CategoryName { get; set; } = string.Empty;

	[JsonPropertyName("SLA_Name")]
	public string SlaName { get; set; } = string.Empty;

	[JsonPropertyName("OpenCategory_Name")]
	public string OpenCategoryName { get; set; } = string.Empty;

	[JsonPropertyName("Source")]
	public string Source { get; set; } = string.Empty;

	[JsonPropertyName("Assigned_Engineer_Email")]
	public string AssignedEngineerEmail { get; set; } = string.Empty;

	[JsonPropertyName("Description")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("PageName")]
	public string PageName { get; set; } = "TicketDetail";

	[JsonPropertyName("Mail_CC_EmailID")]
	public string MailCcEmailId { get; set; } = string.Empty;

	[JsonPropertyName("Symptom")]
	public string Symptom { get; set; } = string.Empty;

}
