using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbDetails
{
	[JsonPropertyName("Configuration_Id")]
	public string? ConfigurationId { get; set; }

	[JsonPropertyName("InstanceName")]
	public string InstanceName { get; set; }

	[JsonPropertyName("Device_Host_Name")]
	public string Hostname { get; set; }

	[JsonPropertyName("Serial_No")]
	public string SerialNumber { get; set; }

	[JsonPropertyName("Owner_Workgroup_Name")]
	public string OwnerWorkgroupName { get; set; }

	[JsonPropertyName("Owner_Name")]
	public string OwnerName { get; set; }

	[JsonPropertyName("Managed_By")]
	public string ManagedBy { get; set; }

	[JsonPropertyName("Classification")]
	public string Classification { get; set; }

	[JsonPropertyName("Status")]
	public string Status { get; set; }

	[JsonPropertyName("LifeCycleStatus")]
	public string LifecycleStatus { get; set; }

	[JsonPropertyName("Criticality_Name")]
	public string CriticalityName { get; set; }

	[JsonPropertyName("Customer")]
	public string Customer { get; set; }

	[JsonPropertyName("VendorName")]
	public string VendorName { get; set; }

	[JsonPropertyName("LocationName")]
	public string LocationName { get; set; }

	[JsonPropertyName("Make")]
	public string Make { get; set; }

	[JsonPropertyName("Mac_Address")]
	public string MacAddress { get; set; }

	[JsonPropertyName("IPAddress")]
	public string IpAddress { get; set; }

	[JsonPropertyName("Model_No")]
	public string ModelNumber { get; set; }

	[JsonPropertyName("Rack")]
	public string Rack { get; set; }

	[JsonPropertyName("Warranty")]
	public string Warranty { get; set; }

	[JsonPropertyName("Annual_Maintains_Contract")]
	public string AnnualMaintainsContract { get; set; }

	[JsonPropertyName("Version")]
	public string Version { get; set; }

	[JsonPropertyName("Description")]
	public string Description { get; set; }

	[JsonPropertyName("Remarks")]
	public string Remarks { get; set; }

	[JsonPropertyName("Test_Plan_Mandatory")]
	public bool IsTestPlanMandatory { get; set; }

	[JsonPropertyName("Purchase_Order_No")]
	public string PurchaseOrderNumber { get; set; }

	[JsonPropertyName("Server_IpAddress")]
	public string ServerIpAddress { get; set; }

	[JsonPropertyName("Server_CPU")]
	public string ServerCpu { get; set; }

	[JsonPropertyName("Server_Hard_Disk_Drive")]
	public string ServerHardDiskDrive { get; set; }

	[JsonPropertyName("Server_RAM")]
	public string ServerRam { get; set; }

	[JsonPropertyName("Server_NIC")]
	public string ServerNic { get; set; }

	[JsonPropertyName("Server_NETWORK")]
	public string ServerNetwork { get; set; }

	[JsonPropertyName("Server_RAID_LEVEL")]
	public string ServerRaidLevel { get; set; }

	[JsonPropertyName("Server_RAID_CARD")]
	public string ServerRaidCard { get; set; }

	[JsonPropertyName("Server_BACKUP_STATE")]
	public bool ServerBackupState { get; set; }

	[JsonPropertyName("Server_BACKUP_DETAILS")]
	public string ServerBackupDetails { get; set; }

	[JsonPropertyName("Server_OPERATING_SYSTEM")]
	public string ServerOperatingSystem { get; set; }

	[JsonPropertyName("Server_SERVICE_PACK")]
	public string ServerServicePack { get; set; }

	[JsonPropertyName("Server_INSTALLED_APPLICATIONS")]
	public string ServerInstalledApplications { get; set; }

	[JsonPropertyName("Server_PATCHES")]
	public string ServerPatches { get; set; }
}
