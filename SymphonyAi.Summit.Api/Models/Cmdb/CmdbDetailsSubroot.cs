using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbDetailsSubroot
{
	[JsonPropertyName("Active")]
	public string Active { get; set; } = string.Empty;

	[JsonPropertyName("AnnualMaintainsContract")]
	public string AnnualMaintenanceContract { get; set; } = string.Empty;

	[JsonPropertyName("CIStatus")]
	public string CiStatus { get; set; } = string.Empty;

	[JsonPropertyName("Classification_Id")]
	public string ClassificationId { get; set; } = string.Empty;

	[JsonPropertyName("Classification")]
	public string Classification { get; set; } = string.Empty;

	[JsonPropertyName("Configuration_Item_Id")]
	public string ConfigurationItemId { get; set; } = string.Empty;

	[JsonPropertyName("criticality")]
	public string Criticality { get; set; } = string.Empty;

	[JsonPropertyName("Criticality_Id")]
	public string CriticalityId { get; set; } = string.Empty;

	[JsonPropertyName("Customer")]
	public string CustomerName { get; set; } = string.Empty;

	[JsonPropertyName("Description")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("Device_Host_Name")]
	public string DeviceHostName { get; set; } = string.Empty;

	[JsonPropertyName("Entity_Type")]
	public string EntityType { get; set; } = string.Empty;

	[JsonPropertyName("IsMonitor")]
	public string IsMonitor { get; set; } = string.Empty;

	[JsonPropertyName("LifeCycleStatus")]
	public string LifecycleStatus { get; set; } = string.Empty;

	[JsonPropertyName("MAC_Address")]
	public string MacAddress { get; set; } = string.Empty;

	[JsonPropertyName("Make")]
	public string Make { get; set; } = string.Empty;

	[JsonPropertyName("Make_Id")]
	public string MakeId { get; set; } = string.Empty;

	[JsonPropertyName("Mananged_By")]
	public string ManangedBy { get; set; } = string.Empty;

	[JsonPropertyName("Model_No")]
	public string ModelNumber { get; set; } = string.Empty;

	[JsonPropertyName("MonitoringCategoryID")]
	public string MonitoringCategoryId { get; set; } = string.Empty;

	[JsonPropertyName("Org_Id")]
	public string OrgId { get; set; } = string.Empty;

	[JsonPropertyName("Owner")]
	public string Owner { get; set; } = string.Empty;

	[JsonPropertyName("Owner_Id")]
	public string OwnerId { get; set; } = string.Empty;

	[JsonPropertyName("Rack")]
	public string Rack { get; set; } = string.Empty;

	[JsonPropertyName("Remarks")]
	public string Remarks { get; set; } = string.Empty;

	[JsonPropertyName("ROWNUM")]
	public string RowNumber { get; set; } = string.Empty;

	[JsonPropertyName("Serial_No")]
	public string SerialNumber { get; set; } = string.Empty;

	[JsonPropertyName("SSHPort")]
	public string SshPort { get; set; } = string.Empty;

	[JsonPropertyName("Sup_Function")]
	public string SupFunction { get; set; } = string.Empty;

	[JsonPropertyName("Sup_Function_Name")]
	public string SupFunctionName { get; set; } = string.Empty;

	[JsonPropertyName("TelnetPort")]
	public string TelnetPort { get; set; } = string.Empty;

	[JsonPropertyName("Test_Plan_Mandatory")]
	public string IsTestPlanMandatory { get; set; } = string.Empty;

	[JsonPropertyName("TotalRows")]
	public string TotalRows { get; set; } = string.Empty;

	[JsonPropertyName("UserAccessId")]
	public string UserAccessId { get; set; } = string.Empty;

	[JsonPropertyName("Vendor_Id")]
	public string VendorId { get; set; } = string.Empty;

	[JsonPropertyName("Vendor_Name")]
	public string VendorName { get; set; } = string.Empty;

	[JsonPropertyName("Version")]
	public string Version { get; set; } = string.Empty;

	[JsonPropertyName("Warranty")]
	public string Warranty { get; set; } = string.Empty;

	[JsonPropertyName("Workgroup")]
	public string Workgroup { get; set; } = string.Empty;

	[JsonPropertyName("Workgroup_Id")]
	public string WorkgroupId { get; set; } = string.Empty;
}
