using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class IncidentDetail2
{
	[JsonPropertyName("Costper_Hour")]
	public /*required*/ object Costper_Hour { get; set; }

	[JsonPropertyName("Org_Id")]
	public int OrgId { get; set; }

	[JsonPropertyName("Ticket_ID")]
	public int TicketId { get; set; }

	[JsonPropertyName("Ticket_No")]
	public /*required*/ string TicketNumber { get; set; }

	[JsonPropertyName("Reg_Time")]
	public /*required*/ string RegTime { get; set; }

	[JsonPropertyName("Status")]
	public /*required*/ string Status { get; set; }

	[JsonPropertyName("Medium")]
	public /*required*/ string Medium { get; set; }

	[JsonPropertyName("LoggedBy")]
	public int LoggedBy { get; set; }

	[JsonPropertyName("LoggedBy_EmailID")]
	public /*required*/ string LoggedByEmailId { get; set; }

	[JsonPropertyName("LoggedByName")]
	public /*required*/ string LoggedByName { get; set; }

	[JsonPropertyName("OpenCategory")]
	public /*required*/ object OpenCategory { get; set; }

	[JsonPropertyName("OpenCategoryID")]
	public /*required*/ object OpenCategoryId { get; set; }

	[JsonPropertyName("Category")]
	public /*required*/ object Category { get; set; }

	[JsonPropertyName("Classification")]
	public /*required*/ object Classification { get; set; }

	[JsonPropertyName("ClassificationID")]
	public /*required*/ object ClassificationId { get; set; }

	[JsonPropertyName("CategoryID")]
	public /*required*/ object CategoryId { get; set; }

	[JsonPropertyName("Subject")]
	public /*required*/ string Subject { get; set; }

	[JsonPropertyName("Pending_Code")]

	public /*required*/ object PendingCode { get; set; }

	[JsonPropertyName("PendingReason")]
	public /*required*/ object PendingReason { get; set; }

	[JsonPropertyName("Severity")]
	public int Severity { get; set; }

	[JsonPropertyName("Severity_Name")]
	public /*required*/ string SeverityName { get; set; }

	[JsonPropertyName("PriorityName")]
	public /*required*/ string PriorityName { get; set; }

	[JsonPropertyName("Severity_Display")]
	public /*required*/ string Severity_Display { get; set; }

	[JsonPropertyName("Criticality")]
	public int Criticality { get; set; }

	[JsonPropertyName("Criticality_Name")]
	public /*required*/ string CriticalityName { get; set; }

	[JsonPropertyName("Impact")]
	public int Impact { get; set; }

	[JsonPropertyName("SLA")]
	public int Sla { get; set; }

	[JsonPropertyName("SLA_Name")]
	public /*required*/ string SlaName { get; set; }

	[JsonPropertyName("Assigned_Workgroup")]
	public int Assigned_Workgroup { get; set; }

	[JsonPropertyName("WG_Name")]
	public /*required*/ string WorkgroupName { get; set; }

	[JsonPropertyName("Assigned_Engineer")]
	public /*required*/ object AssignedEngineer { get; set; }

	[JsonPropertyName("Assigned_Engineer_Name")]
	public /*required*/ object AssignedEngineerName { get; set; }

	[JsonPropertyName("Assigned_Engineer_Email")]
	public /*required*/ object AssignedEngineerEmail { get; set; }

	[JsonPropertyName("Assigned_Engineer_EmpID")]
	public /*required*/ object AssignedEngineerEmpId { get; set; }

	[JsonPropertyName("Response_Deadline")]
	public /*required*/ string ResponseDeadline { get; set; }

	[JsonPropertyName("Response_Time")]
	public /*required*/ object ResponseTime { get; set; }

	[JsonPropertyName("Response_SLA_Met")]
	public /*required*/ object ResponseSlaMet { get; set; }

	[JsonPropertyName("Response_SLA_Reason")]
	public /*required*/ object ResponseSlaReason { get; set; }

	[JsonPropertyName("Resolution_Deadline")]
	public /*required*/ string ResolutionDeadline { get; set; }

	[JsonPropertyName("Resolution_Time")]
	public /*required*/ object ResolutionTime { get; set; }

	[JsonPropertyName("Resolution_SLA_Met")]
	public /*required*/ object ResolutionSlaMet { get; set; }

	[JsonPropertyName("Resolution_SLA_Reason")]
	public /*required*/ object ResolutionSlaReason { get; set; }

	[JsonPropertyName("Closure_Code")]
	public /*required*/ object ClosureCode { get; set; }

	[JsonPropertyName("ClCode_Name")]
	public /*required*/ object ClosureCodeName { get; set; }

	[JsonPropertyName("Repeat_Ticket")]
	public bool Repeat_Ticket { get; set; }

	[JsonPropertyName("Reopen_Ticket")]
	public bool Reopen_Ticket { get; set; }

	[JsonPropertyName("attachments")]
	public bool HasAttachments { get; set; }

	[JsonPropertyName("Information")]
	public /*required*/ string Information { get; set; }

	[JsonPropertyName("Solution")]
	public /*required*/ object Solution { get; set; }

	[JsonPropertyName("Userlog")]
	public /*required*/ object Userlog { get; set; }

	[JsonPropertyName("Internallog")]
	public /*required*/ object Internallog { get; set; }

	[JsonPropertyName("Caller")]
	public int Caller { get; set; }

	[JsonPropertyName("Caller_Name")]
	public /*required*/ string CallerName { get; set; }

	[JsonPropertyName("Caller_EmailID")]
	public /*required*/ string CallerEmailId { get; set; }

	[JsonPropertyName("Sup_Function")]
	public /*required*/ string SuppportFunction { get; set; }

	[JsonPropertyName("Sup_Function_Name")]
	public /*required*/ string SuppportFunctionName { get; set; }

	[JsonPropertyName("KB")]
	public bool HasKnowledgeBase { get; set; }

	[JsonPropertyName("ParentTicketID")]
	public /*required*/ object ParentTicketId { get; set; }

	[JsonPropertyName("Updated_Time1")]
	public /*required*/ string UpdatedTime1 { get; set; }

	[JsonPropertyName("Updated_Time")]
	public /*required*/ string UpdatedTime { get; set; }

	[JsonPropertyName("Schedule_Date")]
	public /*required*/ object ScheduleDate { get; set; }

	[JsonPropertyName("Target_Completion_Date")]
	public /*required*/ object TargetCompletionDate { get; set; }

	[JsonPropertyName("Resolution_SLAOfSeverity")]
	public int ResolutionSlaOfSeverity { get; set; }

	[JsonPropertyName("UserID")]
	public int UserId { get; set; }

	[JsonPropertyName("ManualEscalationDate")]
	public /*required*/ object ManualEscalationDate { get; set; }

	[JsonPropertyName("ManualEscalationLevelID")]
	public /*required*/ object ManualEscalationLevelId { get; set; }

	[JsonPropertyName("ManualEscalationRemarks")]
	public /*required*/ object ManualEscalationRemarks { get; set; }

	[JsonPropertyName("Impact_Name")]
	public /*required*/ string ImpactName { get; set; }

	[JsonPropertyName("NotificationMethod")]
	public /*required*/ object NotificationMethod { get; set; }

	[JsonPropertyName("Configuration_Item_ID")]
	public /*required*/ object ConfigurationItemId { get; set; }

	[JsonPropertyName("Device_Host_Name")]
	public /*required*/ object DeviceHostName { get; set; }

	[JsonPropertyName("WOConfigurationID")]
	public /*required*/ object WOConfigurationId { get; set; }

	[JsonPropertyName("CustomerPriorityDetailID")]
	public /*required*/ object CustomerPriorityDetailId { get; set; }

	[JsonPropertyName("CC_Email")]
	public /*required*/ object CcEmail { get; set; }

	[JsonPropertyName("CC_UserID")]
	public /*required*/ object CcUserId { get; set; }

	[JsonPropertyName("CustomerName")]
	public /*required*/ object CustomerName { get; set; }

	[JsonPropertyName("ParentCustomerName")]
	public /*required*/ object ParentCustomerName { get; set; }

	[JsonPropertyName("CallerLocationName")]
	public /*required*/ object CallerLocationName { get; set; }

	[JsonPropertyName("ContactNo")]
	public /*required*/ object ContactNumber { get; set; }

	[JsonPropertyName("MobileNo")]
	public /*required*/ object MobileNumber { get; set; }

	[JsonPropertyName("FCRTicket")]
	public /*required*/ object FcrTicket { get; set; }

	[JsonPropertyName("FCRComments")]
	public /*required*/ object FcrComments { get; set; }

	[JsonPropertyName("FirstWorkgroup")]
	public int FirstWorkgroup { get; set; }

	[JsonPropertyName("FCRConfigured")]
	public /*required*/ object FcrConfigured { get; set; }

	[JsonPropertyName("Response_PriorityName")]
	public /*required*/ object ResponsePriorityName { get; set; }

	[JsonPropertyName("Response_DeadlineMinutes")]
	public /*required*/ object ResponseDeadlineMinutes { get; set; }

	[JsonPropertyName("OpenCategoryID1")]
	public /*required*/ object OpenCategoryId1 { get; set; }

	[JsonPropertyName("OpenCategory1")]
	public /*required*/ object OpenCategory1 { get; set; }

	[JsonPropertyName("EnableMajorIncident")]
	public /*required*/ object EnableMajorIncident { get; set; }

	[JsonPropertyName("EnableClosureCategory")]
	public /*required*/ object EnableClosureCategory { get; set; }

	[JsonPropertyName("MajorIncident")]
	public /*required*/ object MajorIncident { get; set; }

	[JsonPropertyName("DoNotUpdateChildPriority")]
	public bool DoNotUpdateChildPriority { get; set; }

	[JsonPropertyName("IsSupressNotification")]
	public bool IsSupressNotification { get; set; }

	[JsonPropertyName("ResolutionCode")]
	public /*required*/ object ResolutionCode { get; set; }

	[JsonPropertyName("ResolutionCodeName")]
	public /*required*/ object ResolutionCodeName { get; set; }

	[JsonPropertyName("ClosureRemarks")]
	public /*required*/ object ClosureRemarks { get; set; }

	[JsonPropertyName("TicketClosingMode")]
	public /*required*/ string TicketClosingMode { get; set; }

	[JsonPropertyName("ElapsedTime")]
	public int ElapsedTime { get; set; }

	[JsonPropertyName("Source")]
	public /*required*/ string Source { get; set; }

	[JsonPropertyName("SubWorkgroupName")]
	public object? SubWorkgroupName { get; set; }

	[JsonPropertyName("Linked_CI_IDs")]
	public object? LinkedCiIds { get; set; }

	[JsonPropertyName("Ticket_ID_Encrypted")]
	public /*required*/ string TicketIdEncrypted { get; set; }
}
