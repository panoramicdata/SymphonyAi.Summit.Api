using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting.Incidents;

public class Incident
{
	[JsonPropertyName("Ticket ID")]
	public float TicketId { get; set; }

	[JsonPropertyName("Encripted Ticket ID")]
	public string EncryptedTicketId { get; set; } = string.Empty;

	[JsonPropertyName("Incident ID")]
	public float IncidentId { get; set; }

	[JsonPropertyName("Log Time")]
	public DateTime LogTime { get; set; }

	[JsonPropertyName("Status")]
	public string Status { get; set; } = string.Empty;

	[JsonPropertyName("Medium")]
	public string Medium { get; set; } = string.Empty;

	[JsonPropertyName("Symptom")]
	public string Symptom { get; set; } = string.Empty;

	[JsonPropertyName("Response SLA - Deadline")]
	public DateTime ResponseSLADeadline { get; set; }

	[JsonPropertyName("Response SLA - Actual")]
	public DateTime? ResponseSLAActual { get; set; }

	[JsonPropertyName("Response SLA - Violation")]
	public bool? ResponseSLAViolation { get; set; }

	[JsonPropertyName("Response SLA Violation Reason")]
	public string? ResponseSLAViolationReason { get; set; }

	[JsonPropertyName("Resolution SLA - Deadline")]
	public DateTime ResolutionSLADeadline { get; set; }

	[JsonPropertyName("Resolution SLA - Actual")]
	public string? ResolutionSLAActual { get; set; }

	[JsonPropertyName("Resolution SLA - Violation")]
	public bool? ResolutionSLAViolation { get; set; }

	[JsonPropertyName("Resolution SLA Violation Reason")]
	public string? ResolutionSLAViolationReason { get; set; }

	[JsonPropertyName("Reopen Incident")]
	public bool ReopenIncident { get; set; }

	[JsonPropertyName("Escalation Responsed")]
	public DateTime EscalationResponded { get; set; }

	[JsonPropertyName("Updated Time")]
	public DateTime UpdatedTime { get; set; }

	[JsonPropertyName("Reviewed")]
	public object Reviewed { get; set; } = new();

	[JsonPropertyName("Schedule Date")]
	public DateTime? ScheduleDate { get; set; }

	[JsonPropertyName("Target Completion")]
	public DateTime? TargetCompletion { get; set; }

	[JsonPropertyName("Escalation Level")]
	public object EscalationLevel { get; set; } = new();

	[JsonPropertyName("Escalation Remarks")]
	public string? EscalationRemarks { get; set; }

	[JsonPropertyName("Notification Method")]
	public float? NotificationMethodId { get; set; }

	[JsonPropertyName("Response Elapsetime")]
	public float ResponseElapseTime { get; set; }

	[JsonPropertyName("Resolution Elapsetime")]
	public float ResolutionElapseTime { get; set; }

	[JsonPropertyName("Closure Date")]
	public DateTime? ClosureDate { get; set; }

	[JsonPropertyName("FCR Incident")]
	public bool? FCRIncident { get; set; }

	[JsonPropertyName("FCR Comments")]
	public string? FCRComments { get; set; }

	[JsonPropertyName("Response Deadlineminutes")]
	public string? ResponseDeadlineMinutes { get; set; }

	[JsonPropertyName("Caller Update")]
	public bool CallerUpdate { get; set; }

	[JsonPropertyName("FCR Met")]
	public bool? FCRMet { get; set; }

	[JsonPropertyName("Source")]
	public string Source { get; set; } = string.Empty;

	[JsonPropertyName("Converted To Request")]
	public bool? ConvertedToRequest { get; set; }

	[JsonPropertyName("Converted Type")]
	public string? ConvertedType { get; set; }

	[JsonPropertyName("Child Incident Count")]
	public float? ChildIncidentCount { get; set; }

	[JsonPropertyName("Department Code")]
	public string DepartmentCode { get; set; } = string.Empty;

	[JsonPropertyName("Department Display name")]
	public string DepartmentDisplayName { get; set; } = string.Empty;

	[JsonPropertyName("Customer")]
	public string? CustomerName { get; set; }

	[JsonPropertyName("Location")]
	public string? LocationName { get; set; }

	[JsonPropertyName("Logged By User ID")]
	public float LoggedByUserId { get; set; }

	[JsonPropertyName("Logged By User Name")]
	public string LoggedByUserName { get; set; } = string.Empty;

	[JsonPropertyName("Logged By Empid")]
	public object LoggedByEmpId { get; set; } = string.Empty;

	[JsonPropertyName("Logged By Email")]
	public string LoggedByEmail { get; set; } = string.Empty;

	[JsonPropertyName("Logged By Mobile")]
	public string? LoggedByMobile { get; set; }

	[JsonPropertyName("Logged By Contact")]
	public string? LoggedByContact { get; set; }

	[JsonPropertyName("User ID")]
	public float UserId { get; set; }

	[JsonPropertyName("Employee ID")]
	public string? EmployeeId { get; set; }

	[JsonPropertyName("Caller")]
	public string Caller { get; set; } = string.Empty;

	[JsonPropertyName("Email ID")]
	public string EmailId { get; set; } = string.Empty;

	[JsonPropertyName("Mobile Number")]
	public string? MobileNumber { get; set; }

	[JsonPropertyName("Contact Number")]
	public string? ContactNumber { get; set; }

	[JsonPropertyName("Classification")]
	public string Classification { get; set; } = string.Empty;

	[JsonPropertyName("Category")]
	public string Category { get; set; } = string.Empty;

	[JsonPropertyName("Pending Reason")]
	public string? PendingReason { get; set; }

	[JsonPropertyName("Priority")]
	public string Priority { get; set; } = string.Empty;

	[JsonPropertyName("Priority Display Name")]
	public string PriorityDisplayName { get; set; } = string.Empty;

	[JsonPropertyName("Impact")]
	public string Impact { get; set; } = string.Empty;

	[JsonPropertyName("Service Window")]
	public string ServiceWindow { get; set; } = string.Empty;

	[JsonPropertyName("Workgroup")]
	public string WorkgroupName { get; set; } = string.Empty;

	[JsonPropertyName("Assigned Engineer Userid")]
	public float? AssignedEngineerUserId { get; set; }

	[JsonPropertyName("Assigned To")]
	public string? AssignedToName { get; set; }

	[JsonPropertyName("Assigned Engineer Empid")]
	public string? AssignedEngineerEmpId { get; set; }

	[JsonPropertyName("Assigned Engineer Email")]
	public string? AssignedEngineerEmail { get; set; }

	[JsonPropertyName("Closure Code")]
	public string? ClosureCode { get; set; }

	[JsonPropertyName("Resolution Code")]
	public string? ResolutionCode { get; set; }

	[JsonPropertyName("Customer Matrix Masterid")]
	public int? CustomerMatrixMasterId { get; set; }

	[JsonPropertyName("Response SLA Mins")]
	public float? ResponseSLAMinutes { get; set; }

	[JsonPropertyName("Resolution SLA Mins")]
	public float? ResolutionSLAMinutes { get; set; }

	[JsonPropertyName("Response WG ID")]
	public string? ResponseWGId { get; set; }

	[JsonPropertyName("Response EX ID Userid")]
	public float? ResponseExIdUserId { get; set; }

	[JsonPropertyName("Response EX ID Uname")]
	public string? ResponseExIdUserName { get; set; }

	[JsonPropertyName("Response EX ID Empid")]
	public string? ResponseExIdEmpId { get; set; }

	[JsonPropertyName("Response EX ID Email")]
	public string? ResponseExIdEmail { get; set; }

	[JsonPropertyName("First Workgroup Name")]
	public string FirstWorkgroupName { get; set; } = string.Empty;

	[JsonPropertyName("Response Priority Name")]
	public string? ResponsePriorityName { get; set; }

	[JsonPropertyName("Response Priority Sla")]
	public float? ResponsePrioritySla { get; set; }

	[JsonPropertyName("Response Priority Resolution SLA")]
	public float? ResponsePriorityResolutionSla { get; set; }

	[JsonPropertyName("Rule Name")]
	public string? RuleName { get; set; }

	[JsonPropertyName("Rule Symptom")]
	public string? RuleSymptom { get; set; }

	[JsonPropertyName("Open Category")]
	public string OpenCategory { get; set; } = string.Empty;

	[JsonPropertyName("Service Request ID")]
	public string? ServiceRequestId { get; set; }

	[JsonPropertyName("Vendor ID")]
	public float? VendorId { get; set; }

	[JsonPropertyName("Vendor contact No")]
	public string? VendorContactNumber { get; set; }

	[JsonPropertyName("Vendor Incident ID")]
	public string? VendorIncidentId { get; set; }

	[JsonPropertyName("Vendor Incident Priority")]
	public string? VendorIncidentPriority { get; set; }

	[JsonPropertyName("Vendor Incident Solution")]
	public string? VendorIncidentSolution { get; set; }

	[JsonPropertyName("Vendor Incident Status")]
	public string? VendorIncidentStatus { get; set; }

	[JsonPropertyName("Description")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("Solution")]
	public string? Solution { get; set; } = string.Empty;

	[JsonPropertyName("Urgency")]
	public string Urgency { get; set; } = string.Empty;

	[JsonPropertyName("Total pending Duration SLA Minutes")]
	public float? TotalPendingDurationSLAMinutes { get; set; }

	[JsonPropertyName("Total Pending Duration")]
	public float? TotalPendingDuration { get; set; }

	[JsonPropertyName("Last User Communication")]
	public string? LastUserCommunication { get; set; }

	[JsonPropertyName("private Log")]
	public string PrivateLog { get; set; } = string.Empty;

	[JsonPropertyName("Resolution SLA Met With Pending")]
	public bool ResolutionSLAMetWithPending { get; set; }

	[JsonPropertyName("Link KB On Ticket Resolve")]
	public bool? LinkKbOnTicketResolve { get; set; }

	[JsonPropertyName("Ticket_Age")]
	public string TicketAge { get; set; } = string.Empty;

	[JsonPropertyName("Response SLA In Minutes")]
	public float? ResponseSLAInMinutes { get; set; }

	[JsonPropertyName("Resolution SLA In Minutes")]
	public float? ResolutionSLAInMinutes { get; set; }

	[JsonPropertyName("Response SLA Violated")]
	public int ResponseSLAViolated { get; set; }

	[JsonPropertyName("Resolution SLA Violated")]
	public int ResolutionSLAViolated { get; set; }

	[JsonPropertyName("Highlight Color")]
	public string? HighlightColor { get; set; }

	[JsonPropertyName("Device Host Name")]
	public string? DeviceHostName { get; set; }

	[JsonPropertyName("IP Address")]
	public string? IPAddress { get; set; }

	[JsonPropertyName("MAC Address")]
	public string? MACAddress { get; set; }

	[JsonPropertyName("Model No")]
	public string? ModelNo { get; set; }

	[JsonPropertyName("Purchase Order No")]
	public string? PurchaseOrderNo { get; set; }

	[JsonPropertyName("Serial No")]
	public string? SerialNo { get; set; }

	[JsonPropertyName("Warranty")]
	public string? Warranty { get; set; }

	[JsonPropertyName("Workorder Name")]
	public string? WorkorderName { get; set; }

	[JsonPropertyName("Customer ID")]
	public float CustomerId { get; set; }

	[JsonPropertyName("Tenant ID")]
	public string TenantId { get; set; } = string.Empty;

	[JsonPropertyName("Location ID")]
	public float LocationId { get; set; }

	[JsonPropertyName("Assigned Workgroup ID")]
	public float AssignedWorkgroupId { get; set; }

	[JsonPropertyName("Last User Communication Updated On")]
	public DateTime? LastUserCommunicationUpdatedOn { get; set; }

	[JsonPropertyName("Private Log Updated On")]
	public DateTime PrivateLogUpdatedOn { get; set; }

	[JsonPropertyName("Last Approval Reopen Remark")]
	public string? LastApprovalReopenRemark { get; set; }

	[JsonPropertyName("Last Approval Reopen Remark Date")]
	public DateTime? LastApprovalReopenRemarkDate { get; set; }
}

