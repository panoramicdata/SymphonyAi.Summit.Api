using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbQueryResponseOutputObject
{
	[JsonPropertyName("Org_Id")]
	public int OrgId { get; set; }

	[JsonPropertyName("Configuration_Item_Id")]
	public string ConfigurationItemId { get; set; } = string.Empty;

	[JsonPropertyName("Sup_Function")]
	public string SupFunction { get; set; } = string.Empty;

	[JsonPropertyName("Sup_Function_Name")]
	public string SupFunctionName { get; set; } = string.Empty;

	[JsonPropertyName("Device_Host_Name")]
	public string DeviceHostName { get; set; } = string.Empty;

	[JsonPropertyName("Classification_Id")]
	public int ClassificationId { get; set; }

	[JsonPropertyName("Classification")]
	public string Classification { get; set; } = string.Empty;

	[JsonPropertyName("Serial_No")]
	public string SerialNo { get; set; } = string.Empty;

	[JsonPropertyName("MAC_Address")]
	public string MacAddress { get; set; } = string.Empty;

	[JsonPropertyName("Model_No")]
	public string ModelNumber { get; set; } = string.Empty;

	[JsonPropertyName("Entity_ID")]
	public int? EntityId { get; set; }

	[JsonPropertyName("Entity_Type")]
	public string EntityType { get; set; } = string.Empty;

	[JsonPropertyName("Make_Id")]
	public int MakeId { get; set; }

	[JsonPropertyName("Make")]
	public string Make { get; set; } = string.Empty;

	[JsonPropertyName("Workgroup_Id")]
	public int WorkgroupId { get; set; }

	[JsonPropertyName("Workgroup")]
	public string Workgroup { get; set; } = string.Empty;

	[JsonPropertyName("Owner_Id")]
	public int OwnerId { get; set; }

	[JsonPropertyName("Owner")]
	public string Owner { get; set; } = string.Empty;

	[JsonPropertyName("Mananged_By")]
	public string ManagedBy { get; set; } = string.Empty;

	[JsonPropertyName("Vendor_Id")]
	public int VendorId { get; set; }

	[JsonPropertyName("Vendor_Name")]
	public string? VendorName { get; set; }

	[JsonPropertyName("Purchase_Order_No")]
	public string PurchaseOrderNo { get; set; } = string.Empty;

	[JsonPropertyName("Bond_No")]
	public object? BondNumber { get; set; }

	[JsonPropertyName("Installation_Date")]
	public string InstallationDate { get; set; } = string.Empty;

	[JsonPropertyName("Customer")]
	public string Customer { get; set; } = string.Empty;

	[JsonPropertyName("Criticality_Id")]
	public int CriticalityId { get; set; }

	[JsonPropertyName("Criticality")]
	public string Criticality { get; set; } = string.Empty;

	[JsonPropertyName("Location")]
	public string Location { get; set; } = string.Empty;

	[JsonPropertyName("Rack")]
	public string Rack { get; set; } = string.Empty;

	[JsonPropertyName("Warranty")]
	public string Warranty { get; set; } = string.Empty;

	[JsonPropertyName("Annual_Maintains_Contract")]
	public string AnnualMaintainsContract { get; set; } = string.Empty;

	[JsonPropertyName("Version")]
	public string Version { get; set; } = string.Empty;

	[JsonPropertyName("Description")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("Remarks")]
	public string Remarks { get; set; } = string.Empty;

	[JsonPropertyName("Network_Device_IP_Address")]
	public string? NetworkDeviceIpAddress { get; set; }

	[JsonPropertyName("Server_IP_Address")]
	public string? ServerIpAddress { get; set; }

	[JsonPropertyName("Desktop_IP_Address")]
	public string? DesktopIpAddress { get; set; }

	[JsonPropertyName("IP_Address")]
	public string? IpAddress { get; set; }

	[JsonPropertyName("Active")]
	public bool IsActive { get; set; }

	[JsonPropertyName("Test_Plan_Mandatory")]
	public bool IsTestPlanMandatory { get; set; }

	[JsonPropertyName("IsMonitor")]
	public bool IsMonitor { get; set; }

	[JsonPropertyName("CIStatus")]
	public string CiStatus { get; set; } = string.Empty;

	[JsonPropertyName("LifeCycleStatus")]
	public string LifecycleStatus { get; set; } = string.Empty;

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
	public int UserAccessId { get; set; }

	[JsonPropertyName("SSHPort")]
	public int SshPort { get; set; }

	[JsonPropertyName("TelnetPort")]
	public int TelnetPort { get; set; }
}