using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbDetailsSubroot
{
	[JsonPropertyName("Active")]
	public string Active { get; set; }

	[JsonPropertyName("CIStatus")]
	public string CiStatus { get; set; }

	[JsonPropertyName("Classification_Id")]
	public string ClassificationId { get; set; }

	[JsonPropertyName("Configuration_Item_Id")]
	public string ConfigurationItemId { get; set; }

	[JsonPropertyName("criticality")]
	public string Criticality { get; set; }

	[JsonPropertyName("Criticality_Id")]
	public string CriticalityId { get; set; }

	[JsonPropertyName("Customer")]
	public string CustomerName { get; set; }

	[JsonPropertyName("Description")]
	public string Description { get; set; }

	[JsonPropertyName("Device_Host_Name")]
	public string DeviceHostName { get; set; }

	[JsonPropertyName("Entity_Type")]
	public string EntityType { get; set; }

	[JsonPropertyName("IsMonitor")]
	public string IsMonitor { get; set; }

	[JsonPropertyName("LifeCycleStatus")]
	public string LifecycleStatus { get; set; }

	[JsonPropertyName("MAC_Address")]
	public string MacAddress { get; set; }

	[JsonPropertyName("Make")]
	public string Make { get; set; }

	[JsonPropertyName("Make_Id")]
	public string MakeId { get; set; }

	[JsonPropertyName("Mananged_By")]
	public string ManangedBy { get; set; }

	[JsonPropertyName("Model_No")]
	public string ModelNumber { get; set; }

	[JsonPropertyName("MonitoringCategoryID")]
	public string MonitoringCategoryId { get; set; }

	[JsonPropertyName("Org_Id")]
	public string OrgId { get; set; }

	[JsonPropertyName("Owner")]
	public string Owner { get; set; }

	[JsonPropertyName("Owner_Id")]
	public string OwnerId { get; set; }

	[JsonPropertyName("Rack")]
	public string Rack { get; set; }

	[JsonPropertyName("Remarks")]
	public string Remarks { get; set; }

	[JsonPropertyName("ROWNUM")]
	public string RowNumber { get; set; }

	[JsonPropertyName("Serial_No")]
	public string SerialNumber { get; set; }

	[JsonPropertyName("SSHPort")]
	public string SshPort { get; set; }

	[JsonPropertyName("Sup_Function")]
	public string SupFunction { get; set; }

	[JsonPropertyName("Sup_Function_Name")]
	public string SupFunctionName { get; set; }

	[JsonPropertyName("TelnetPort")]
	public string TelnetPort { get; set; }

	[JsonPropertyName("Test_Plan_Mandatory")]
	public string IsTestPlanMandatory { get; set; }

	[JsonPropertyName("TotalRows")]
	public string TotalRows { get; set; }

	[JsonPropertyName("UserAccessId")]
	public string UserAccessId { get; set; }

	[JsonPropertyName("Vendor_Id")]
	public string VendorId { get; set; }

	[JsonPropertyName("Vendor_Name")]
	public string VendorName { get; set; }

	[JsonPropertyName("Version")]
	public string Version { get; set; }

	[JsonPropertyName("Warranty")]
	public string Warranty { get; set; }

	[JsonPropertyName("Workgroup")]
	public string Workgroup { get; set; }

	[JsonPropertyName("Workgroup_Id")]
	public string WorkgroupId { get; set; }
}
