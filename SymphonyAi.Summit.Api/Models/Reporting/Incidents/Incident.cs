using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting.Incidents;

[DataContract]
public class Incident
{
	[DataMember(Name = "Ticket ID")]
	public float TicketId { get; set; }

	[DataMember(Name = "Encripted Ticket ID")]
	public string EncryptedTicketId { get; set; } = string.Empty;

	[DataMember(Name = "Incident ID")]
	public float IncidentId { get; set; }

	[DataMember(Name = "Log Time")]
	public DateTime LogTime { get; set; }

	[DataMember(Name = "Status")]
	public string Status { get; set; } = string.Empty;

	[DataMember(Name = "Medium")]
	public string Medium { get; set; } = string.Empty;

	[DataMember(Name = "Symptom")]
	public string Symptom { get; set; } = string.Empty;

	[DataMember(Name = "Response SLA - Deadline")]
	public DateTime ResponseSLADeadline { get; set; }

	[DataMember(Name = "Response SLA - Actual")]
	public DateTime? ResponseSLAActual { get; set; }

	[DataMember(Name = "Response SLA - Violation")]
	public bool? ResponseSLAViolation { get; set; }

	[DataMember(Name = "Response SLA Violation Reason")]
	public string? ResponseSLAViolationReason { get; set; }

	[DataMember(Name = "Resolution SLA - Deadline")]
	public DateTime ResolutionSLADeadline { get; set; }

	[DataMember(Name = "Resolution SLA - Actual")]
	public string? ResolutionSLAActual { get; set; }

	[DataMember(Name = "Resolution SLA - Violation")]
	public bool? ResolutionSLAViolation { get; set; }

	[DataMember(Name = "Resolution SLA Violation Reason")]
	public string? ResolutionSLAViolationReason { get; set; }

	[DataMember(Name = "Reopen Incident")]
	public bool ReopenIncident { get; set; }

	[DataMember(Name = "Escalation Responsed")]
	public DateTime EscalationResponded { get; set; }

	[DataMember(Name = "Updated Time")]
	public DateTime UpdatedTime { get; set; }

	[DataMember(Name = "Reviewed")]
	public object Reviewed { get; set; } = new();

	[DataMember(Name = "Schedule Date")]
	public DateTime? ScheduleDate { get; set; }

	[DataMember(Name = "Target Completion")]
	public DateTime? TargetCompletion { get; set; }

	[DataMember(Name = "Escalation Level")]
	public object EscalationLevel { get; set; } = new();

	[DataMember(Name = "Escalation Remarks")]
	public string? EscalationRemarks { get; set; }

	[DataMember(Name = "Notification Method")]
	public float? NotificationMethodId { get; set; }

	[DataMember(Name = "Response Elapsetime")]
	public float ResponseElapseTime { get; set; }

	[DataMember(Name = "Resolution Elapsetime")]
	public float ResolutionElapseTime { get; set; }

	[DataMember(Name = "Closure Date")]
	public DateTime? ClosureDate { get; set; }

	[DataMember(Name = "FCR Incident")]
	public bool? FCRIncident { get; set; }

	[DataMember(Name = "FCR Comments")]
	public string? FCRComments { get; set; }

	[DataMember(Name = "Response Deadlineminutes")]
	public string? ResponseDeadlineMinutes { get; set; }

	[DataMember(Name = "Caller Update")]
	public bool CallerUpdate { get; set; }

	[DataMember(Name = "FCR Met")]
	public bool? FCRMet { get; set; }

	[DataMember(Name = "Source")]
	public string Source { get; set; } = string.Empty;

	[DataMember(Name = "Converted To Request")]
	public bool? ConvertedToRequest { get; set; }

	[DataMember(Name = "Converted Type")]
	public string? ConvertedType { get; set; }

	[DataMember(Name = "Child Incident Count")]
	public float? ChildIncidentCount { get; set; }

	[DataMember(Name = "Department Code")]
	public string DepartmentCode { get; set; } = string.Empty;

	[DataMember(Name = "Department Display name")]
	public string DepartmentDisplayName { get; set; } = string.Empty;

	[DataMember(Name = "Customer")]
	public string? CustomerName { get; set; }

	[DataMember(Name = "Location")]
	public string? LocationName { get; set; }

	[DataMember(Name = "Logged By User ID")]
	public float LoggedByUserId { get; set; }

	[DataMember(Name = "Logged By User Name")]
	public string LoggedByUserName { get; set; } = string.Empty;

	[DataMember(Name = "Logged By Empid")]
	public object LoggedByEmpId { get; set; } = string.Empty;

	[DataMember(Name = "Logged By Email")]
	public string LoggedByEmail { get; set; } = string.Empty;

	[DataMember(Name = "Logged By Mobile")]
	public string? LoggedByMobile { get; set; }

	[DataMember(Name = "Logged By Contact")]
	public string? LoggedByContact { get; set; }

	[DataMember(Name = "User ID")]
	public float UserId { get; set; }

	[DataMember(Name = "Employee ID")]
	public string? EmployeeId { get; set; }

	[DataMember(Name = "Caller")]
	public string Caller { get; set; } = string.Empty;

	[DataMember(Name = "Email ID")]
	public string EmailId { get; set; } = string.Empty;

	[DataMember(Name = "Mobile Number")]
	public string? MobileNumber { get; set; }

	[DataMember(Name = "Contact Number")]
	public string? ContactNumber { get; set; }

	[DataMember(Name = "Classification")]
	public string Classification { get; set; } = string.Empty;

	[DataMember(Name = "Category")]
	public string Category { get; set; } = string.Empty;

	[DataMember(Name = "Pending Reason")]
	public string? PendingReason { get; set; }

	[DataMember(Name = "Priority")]
	public string Priority { get; set; } = string.Empty;

	[DataMember(Name = "Priority Display Name")]
	public string PriorityDisplayName { get; set; } = string.Empty;

	[DataMember(Name = "Impact")]
	public string Impact { get; set; } = string.Empty;

	[DataMember(Name = "Service Window")]
	public string ServiceWindow { get; set; } = string.Empty;

	[DataMember(Name = "Workgroup")]
	public string Workgroup { get; set; } = string.Empty;

	[DataMember(Name = "Assigned Engineer Userid")]
	public float? AssignedEngineerUserId { get; set; }

	[DataMember(Name = "Assigned To")]
	public string? AssignedToName { get; set; }

	[DataMember(Name = "Assigned Engineer Empid")]
	public string? AssignedEngineerEmpId { get; set; }

	[DataMember(Name = "Assigned Engineer Email")]
	public string? AssignedEngineerEmail { get; set; }

	[DataMember(Name = "Closure Code")]
	public string? ClosureCode { get; set; }

	[DataMember(Name = "Resolution Code")]
	public string? ResolutionCode { get; set; }

	[DataMember(Name = "Customer Matrix Masterid")]
	public int? CustomerMatrixMasterId { get; set; }

	[DataMember(Name = "Response SLA Mins")]
	public float? ResponseSLAMinutes { get; set; }

	[DataMember(Name = "Resolution SLA Mins")]
	public float? ResolutionSLAMinutes { get; set; }

	[DataMember(Name = "Response WG ID")]
	public string? ResponseWGId { get; set; }

	[DataMember(Name = "Response EX ID Userid")]
	public float? ResponseExIdUserId { get; set; }

	[DataMember(Name = "Response EX ID Uname")]
	public string? ResponseExIdUserName { get; set; }

	[DataMember(Name = "Response EX ID Empid")]
	public string? ResponseExIdEmpId { get; set; }

	[DataMember(Name = "Response EX ID Email")]
	public string? ResponseExIdEmail { get; set; }

	[DataMember(Name = "First Workgroup Name")]
	public string FirstWorkgroupName { get; set; } = string.Empty;

	[DataMember(Name = "Response Priority Name")]
	public string? ResponsePriorityName { get; set; }

	[DataMember(Name = "Response Priority Sla")]
	public float? ResponsePrioritySla { get; set; }

	[DataMember(Name = "Response Priority Resolution SLA")]
	public float? ResponsePriorityResolutionSla { get; set; }

	[DataMember(Name = "Rule Name")]
	public string? RuleName { get; set; }

	[DataMember(Name = "Rule Symptom")]
	public string? RuleSymptom { get; set; }

	[DataMember(Name = "Open Category")]
	public string OpenCategory { get; set; } = string.Empty;

	[DataMember(Name = "Service Request ID")]
	public string? ServiceRequestId { get; set; }

	[DataMember(Name = "Vendor ID")]
	public float? VendorId { get; set; }

	[DataMember(Name = "Vendor contact No")]
	public string? VendorContactNumber { get; set; }

	[DataMember(Name = "Vendor Incident ID")]
	public string? VendorIncidentId { get; set; }

	[DataMember(Name = "Vendor Incident Priority")]
	public string? VendorIncidentPriority { get; set; }

	[DataMember(Name = "Vendor Incident Solution")]
	public string? VendorIncidentSolution { get; set; }

	[DataMember(Name = "Vendor Incident Status")]
	public string? VendorIncidentStatus { get; set; }

	[DataMember(Name = "Description")]
	public string Description { get; set; } = string.Empty;

	[DataMember(Name = "Solution")]
	public string? Solution { get; set; } = string.Empty;

	[DataMember(Name = "Urgency")]
	public string Urgency { get; set; } = string.Empty;

	[DataMember(Name = "Total pending Duration SLA Minutes")]
	public float? TotalPendingDurationSLAMinutes { get; set; }

	[DataMember(Name = "Total Pending Duration")]
	public float? TotalPendingDuration { get; set; }

	[DataMember(Name = "Last User Communication")]
	public string? LastUserCommunication { get; set; }

	[DataMember(Name = "private Log")]
	public string PrivateLog { get; set; } = string.Empty;

	[DataMember(Name = "Resolution SLA Met With Pending")]
	public bool ResolutionSLAMetWithPending { get; set; }

	[DataMember(Name = "Link KB On Ticket Resolve")]
	public bool? LinkKbOnTicketResolve { get; set; }

	[DataMember(Name = "Ticket_Age")]
	public string TicketAge { get; set; } = string.Empty;

	[DataMember(Name = "Response SLA In Minutes")]
	public float? ResponseSLAInMinutes { get; set; }

	[DataMember(Name = "Resolution SLA In Minutes")]
	public float? ResolutionSLAInMinutes { get; set; }

	[DataMember(Name = "Response SLA Violated")]
	public int ResponseSLAViolated { get; set; }

	[DataMember(Name = "Resolution SLA Violated")]
	public int ResolutionSLAViolated { get; set; }

	[DataMember(Name = "Highlight Color")]
	public string? HighlightColor { get; set; }

	[DataMember(Name = "Device Host Name")]
	public string? DeviceHostName { get; set; }

	[DataMember(Name = "IP Address")]
	public string? IPAddress { get; set; }

	[DataMember(Name = "MAC Address")]
	public string? MACAddress { get; set; }

	[DataMember(Name = "Model No")]
	public string? ModelNo { get; set; }

	[DataMember(Name = "Purchase Order No")]
	public string? PurchaseOrderNo { get; set; }

	[DataMember(Name = "Serial No")]
	public string? SerialNo { get; set; }

	[DataMember(Name = "Warranty")]
	public string? Warranty { get; set; }

	[DataMember(Name = "Workorder Name")]
	public string? WorkorderName { get; set; }

	[DataMember(Name = "Customer ID")]
	public float CustomerId { get; set; }

	[DataMember(Name = "Tenant ID")]
	public string TenantId { get; set; } = string.Empty;

	[DataMember(Name = "Location ID")]
	public float LocationId { get; set; }

	[DataMember(Name = "Assigned Workgroup ID")]
	public float AssignedWorkgroupId { get; set; }

	[DataMember(Name = "Last User Communication Updated On")]
	public DateTime? LastUserCommunicationUpdatedOn { get; set; }

	[DataMember(Name = "Private Log Updated On")]
	public DateTime PrivateLogUpdatedOn { get; set; }

	[DataMember(Name = "Last Approval Reopen Remark")]
	public string? LastApprovalReopenRemark { get; set; }

	[DataMember(Name = "Last Approval Reopen Remark Date")]
	public DateTime? LastApprovalReopenRemarkDate { get; set; }
}

