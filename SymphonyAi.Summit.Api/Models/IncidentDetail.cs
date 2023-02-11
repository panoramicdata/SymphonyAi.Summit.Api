using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class IncidentDetail
{

	[JsonPropertyName("ROWNUM")]
	public int RowId { get; set; }

	[JsonPropertyName("Ticket_ID")]
	public /*required*/ int TicketId { get; set; }

	[JsonPropertyName("TotalRows")]
	public int TotalRowCount { get; set; }

	[JsonPropertyName("Incident_ID")]
	public int IncidentId { get; set; }

	[JsonPropertyName("Logged_Time")]
	public /*required*/ string LoggedTime { get; set; }

	[JsonPropertyName("Status")]
	public /*required*/ string Status { get; set; }

	[JsonPropertyName("Symptom")]
	public /*required*/ string Symptom { get; set; }

	[JsonPropertyName("Workgroup_Name")]
	public /*required*/ string WorkgroupName { get; set; }

	[JsonPropertyName("Executive_Name")]
	public /*required*/ string ExecutiveName { get; set; }

	[JsonPropertyName("Assigned_Engineer")]
	public /*required*/ object AssignedEngineer { get; set; }

	[JsonPropertyName("Priority")]
	public /*required*/ string Priority { get; set; }

	[JsonPropertyName("PriorityColorCode")]
	public /*required*/ string PriorityColorCode { get; set; }

	[JsonPropertyName("Resolution_SLA")]
	public int Resolution_SLA { get; set; }

	[JsonPropertyName("SLAName")]
	public /*required*/ string SlaName { get; set; }

	[JsonPropertyName("CallerName")]
	public /*required*/ string CallerName { get; set; }

	[JsonPropertyName("Caller_EmailId")]
	public /*required*/ string CallerEmailId { get; set; }

	[JsonPropertyName("UserTypeColor")]
	public /*required*/ object UserTypeColor { get; set; }

	[JsonPropertyName("UserTypeName")]
	public /*required*/ object UserTypeName { get; set; }

	[JsonPropertyName("Resolution_Time")]
	public /*required*/ object ResolutionTime { get; set; }

	[JsonPropertyName("Age")]
	public int Age { get; set; }

	[JsonPropertyName("Response_ElapseTime")]
	public int Response_ElapseTime { get; set; }

	[JsonPropertyName("Resolution_ElapseTime")]
	public int Resolution_ElapseTime { get; set; }

	[JsonPropertyName("Response_SLA_Reason")]
	public /*required*/ string ResponseSlaReason { get; set; }

	[JsonPropertyName("Resolution_SLA_Reason")]
	public /*required*/ string ResolutionSlaReason { get; set; }

	[JsonPropertyName("SLAProgress")]
	public int SlaProgress { get; set; }

	[JsonPropertyName("IsParentRecord")]
	public int IsParentRecord { get; set; }

	[JsonPropertyName("UserProfileImageName")]
	public /*required*/ string UserProfileImageName { get; set; }

	[JsonPropertyName("CallerUpdate")]
	public /*required*/ object CallerUpdate { get; set; }

	[JsonPropertyName("IsChild")]
	public int IsChild { get; set; }

	[JsonPropertyName("IsParent")]
	public int IsParent { get; set; }

	[JsonPropertyName("AssignedToMe")]
	public int AssignedToMe { get; set; }

	[JsonPropertyName("Reopened")]
	public bool Reopened { get; set; }

	[JsonPropertyName("Sup_Function")]
	public /*required*/ string SupFunction { get; set; }

	[JsonPropertyName("SLARemainingTime")]
	public int SlaRemainingTime { get; set; }

	[JsonPropertyName("Updated_Time")]
	public /*required*/ string UpdatedTime { get; set; }

	[JsonPropertyName("Customer")]
	public /*required*/ object Customer { get; set; }

	[JsonPropertyName("Location")]
	public /*required*/ object Location { get; set; }

	[JsonPropertyName("Urgency")]
	public /*required*/ string Urgency { get; set; }

	[JsonPropertyName("Impact")]
	public /*required*/ string Impact { get; set; }

	[JsonPropertyName("Classification")]
	public /*required*/ object Classification { get; set; }

	[JsonPropertyName("FullClassification")]
	public /*required*/ object FullClassification { get; set; }

	[JsonPropertyName("Category")]
	public /*required*/ object Category { get; set; }

	[JsonPropertyName("FullCategory")]
	public /*required*/ object FullCategory { get; set; }

	[JsonPropertyName("OpenCategory")]
	public /*required*/ object OpenCategory { get; set; }

	[JsonPropertyName("FullOpenCategory")]
	public /*required*/ object FullOpenCategory { get; set; }

	[JsonPropertyName("Pending_Reason")]
	public /*required*/ object PendingReason { get; set; }

	[JsonPropertyName("Schedule_Date")]
	public /*required*/ object ScheduleDate { get; set; }

	[JsonPropertyName("Service_Window")]
	public /*required*/ string ServiceWindow { get; set; }

	[JsonPropertyName("IsAttExists")]
	public int IsAttExists { get; set; }

	[JsonPropertyName("IsAutoResolve")]
	public int IsAutoResolve { get; set; }

	[JsonPropertyName("Vendor_Incident_ID")]
	public /*required*/ string VendorIncidentId { get; set; }

	[JsonPropertyName("Vendor_Name")]
	public /*required*/ string VendorName { get; set; }

	[JsonPropertyName("Vendor_status")]
	public /*required*/ string VendorStatus { get; set; }

	[JsonPropertyName("VendorIncidentStartDate")]
	public /*required*/ object VendorIncidentStartDate { get; set; }

	[JsonPropertyName("VendorIncidentEndDate")]
	public /*required*/ object VendorIncidentEndDate { get; set; }

	[JsonPropertyName("Assigned_Engineer_Name_Secondary")]
	public /*required*/ string AssignedEngineerNameSecondary { get; set; }

	[JsonPropertyName("Response_voilation")]
	public /*required*/ object ResponseViolation { get; set; }

	[JsonPropertyName("Resolution_voilation")]
	public /*required*/ object ResolutionViolation { get; set; }

	[JsonPropertyName("Response_Deadline")]
	public /*required*/ string ResponseDeadline { get; set; }

	[JsonPropertyName("Resolution_Deadline")]
	public /*required*/ string ResolutionDeadline { get; set; }

	[JsonPropertyName("Reslution_Code_Name")]
	public /*required*/ object ReslutionCodeName { get; set; }

	[JsonPropertyName("Closure_Code_Name")]
	public /*required*/ object ClosureCodeName { get; set; }

	[JsonPropertyName("IsMajorIncident")]
	public /*required*/ string IsMajorIncident { get; set; }

	[JsonPropertyName("AgeClass")]
	public /*required*/ string AgeClass { get; set; }

	[JsonPropertyName("AgingInfo")]
	public /*required*/ string AgingInfo { get; set; }

	[JsonPropertyName("SLAPercent")]
	public /*required*/ string SlaPercent { get; set; }

	[JsonPropertyName("SLAProgressClass")]
	public /*required*/ object SlaProgressClass { get; set; }

	[JsonPropertyName("Remaining_SLA_Time")]
	public /*required*/ string RemainingSlaTime { get; set; }

	[JsonPropertyName("SubWorkgroup_Name")]
	public /*required*/ object SubWorkgroupName { get; set; }

	[JsonPropertyName("Description")]
	public /*required*/ string Description { get; set; }

	[JsonPropertyName("Solution")]
	public /*required*/ object Solution { get; set; }

	[JsonPropertyName("User_Log")]
	public /*required*/ object UserLog { get; set; }

	[JsonPropertyName("Private_Log")]
	public /*required*/ object PrivateLog { get; set; }

	[JsonPropertyName("AttachmentNames")]
	public /*required*/ object AttachmentNames { get; set; }
}
