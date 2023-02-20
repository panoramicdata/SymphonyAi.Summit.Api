using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbDetail
{

	[JsonPropertyName("ROWNUM")]
	public string RowNumber { get; set; }

	[JsonPropertyName("TotalRows")]
	public int TotalRows { get; set; }

	[JsonPropertyName("Org_Id")]
	public int OrgId { get; set; }

	[JsonPropertyName("Configuration_Item_Id")]
	public string ConfigurationItemId { get; set; }

	[JsonPropertyName("Sup_Function")]
	public string SupFunction { get; set; }

	[JsonPropertyName("Sup_Function_Name")]
	public string SupFunctionName { get; set; }

	[JsonPropertyName("Device_Host_Name")]
	public string DeviceHostName { get; set; }

	[JsonPropertyName("Classification_Id")]
	public int ClassificationId { get; set; }

	[JsonPropertyName("Classification")]
	public string Classification { get; set; }

	[JsonPropertyName("Serial_No")]
	public string SerialNumber { get; set; }

	[JsonPropertyName("MAC_Address")]
	public string MacAddress { get; set; }

	[JsonPropertyName("Model_No")]
	public string ModelNumber { get; set; }

	[JsonPropertyName("Entity_ID")]
	public int? EntityId { get; set; }

	[JsonPropertyName("Entity_Type")]
	public string EntityType { get; set; }

	[JsonPropertyName("Make_Id")]
	public int MakeId { get; set; }

	[JsonPropertyName("Make")]
	public string Make { get; set; }

	[JsonPropertyName("Workgroup_Id")]
	public int WorkgroupId { get; set; }

	[JsonPropertyName("Workgroup")]
	public string Workgroup { get; set; }

	[JsonPropertyName("Owner_Id")]
	public int OwnerId { get; set; }

	[JsonPropertyName("Owner")]
	public string Owner { get; set; }

	[JsonPropertyName("Mananged_By")]
	public string ManagedBy { get; set; }

	[JsonPropertyName("Vendor_Id")]
	public string VendorId { get; set; }

	[JsonPropertyName("Vendor_Name")]
	public string VendorName { get; set; }

	[JsonPropertyName("Purchase_Order_No")]
	public object PurchaseOrderNumber { get; set; }

	[JsonPropertyName("Bond_No")]
	public object BondNumber { get; set; }

	[JsonPropertyName("Installation_Date")]
	public object InstallationDate { get; set; }

	[JsonPropertyName("Customer")]
	public string Customer { get; set; }

	[JsonPropertyName("Criticality_Id")]
	public int CriticalityId { get; set; }

	[JsonPropertyName("criticality")]
	public string Criticality { get; set; }

	[JsonPropertyName("Location")]
	public string? Location { get; set; }

	[JsonPropertyName("Rack")]
	public string Rack { get; set; }

	[JsonPropertyName("Warranty")]
	public string Warranty { get; set; }

	[JsonPropertyName("Annual_Maintains_Contract")]
	public string? AnnualMaintenanceContract { get; set; }

	[JsonPropertyName("Version")]
	public string Version { get; set; }

	[JsonPropertyName("Description")]
	public string Description { get; set; }

	[JsonPropertyName("Remarks")]
	public string Remarks { get; set; }

	[JsonPropertyName("Network_Device_IP_Address")]
	public string? NetworkDeviceIpAddress { get; set; }

	[JsonPropertyName("Server_IP_Address")]
	public string? ServerIpAddress { get; set; }

	[JsonPropertyName("Desktop_IP_Address")]
	public string? DesktopIpAddress { get; set; }

	[JsonPropertyName("IP_Address")]
	public string? IpAddress { get; set; }

	[JsonPropertyName("Active")]
	public bool Active { get; set; }

	[JsonPropertyName("Test_Plan_Mandatory")]
	public string TestPlanMandatory { get; set; }

	[JsonPropertyName("IsMonitor")]
	public bool IsMonitor { get; set; }

	[JsonPropertyName("CIStatus")]
	public string CiStatus { get; set; }

	[JsonPropertyName("LifeCycleStatus")]
	public string LifecycleStatus { get; set; }

	[JsonPropertyName("SLAID")]
	public int? SlaId { get; set; }

	[JsonPropertyName("ProjectID")]
	public int? ProjectId { get; set; }

	[JsonPropertyName("Service_EntitlementID")]
	public int? ServiceEntitlementId { get; set; }

	[JsonPropertyName("Service_Entitlement_Name")]
	public string? ServiceEntitlementName { get; set; }

	[JsonPropertyName("Color_Code")]
	public string? ColorCode { get; set; }

	[JsonPropertyName("MonitoringCategoryID")]
	public int MonitoringCategoryId { get; set; }

	[JsonPropertyName("MonitoringCategoryName")]
	public string? MonitoringCategoryName { get; set; }

	[JsonPropertyName("UserAccessId")]
	public string UserAccessId { get; set; }

	[JsonPropertyName("SSHPort")]
	public string SshPort { get; set; }

	[JsonPropertyName("TelnetPort")]
	public string TelnetPort { get; set; }

	[JsonPropertyName("DiscoverySource")]
	public string? DiscoverySource { get; set; }

	[JsonPropertyName("CreateDt")]
	public string CreateDt { get; set; }

	[JsonPropertyName("UpdateDt")]
	public string? UpdateDt { get; set; }
}