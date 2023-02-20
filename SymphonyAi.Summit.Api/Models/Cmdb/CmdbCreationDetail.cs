using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbCreationDetail
{
	[JsonPropertyName("Configuration_Item_Id")]
	public string? ConfigurationItemId { get; set; }

	[JsonPropertyName("InstanceName")]
	public string InstanceName { get; set; } = string.Empty;

	[JsonPropertyName("Device_Host_Name")]
	public string DeviceHostName { get; set; } = string.Empty;

	[JsonPropertyName("Serial_No")]
	public string SerialNumber { get; set; } = string.Empty;

	[JsonPropertyName("Owner_Workgroup_Name")]
	public string Workgroup { get; set; } = string.Empty;

	[JsonPropertyName("Owner_Name")]
	public string OwnerName { get; set; } = string.Empty;

	[JsonPropertyName("Managed_By")]
	public string ManagedBy { get; set; } = string.Empty;

	[JsonPropertyName("Classification")]
	public string Classification { get; set; } = string.Empty;

	[JsonPropertyName("Status")]
	public string Status { get; set; } = string.Empty;

	[JsonPropertyName("LifeCycleStatus")]
	public string LifecycleStatus { get; set; } = string.Empty;

	[JsonPropertyName("Criticality_Name")]
	public string CriticalityName { get; set; } = string.Empty;

	[JsonPropertyName("Customer")]
	public string Customer { get; set; } = string.Empty;

	[JsonPropertyName("VendorName")]
	public string VendorName { get; set; } = string.Empty;

	[JsonPropertyName("LocationName")]
	public string LocationName { get; set; } = string.Empty;

	[JsonPropertyName("Make")]
	public string Make { get; set; } = string.Empty;

	[JsonPropertyName("Mac_Address")]
	public string MacAddress { get; set; } = string.Empty;

	[JsonPropertyName("IPAddress")]
	public string IpAddress { get; set; } = string.Empty;

	[JsonPropertyName("Model_No")]
	public string ModelNumber { get; set; } = string.Empty;

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

	[JsonPropertyName("Test_Plan_Mandatory")]
	public bool IsTestPlanMandatory { get; set; }

	[JsonPropertyName("Purchase_Order_No")]
	public string PurchaseOrderNumber { get; set; } = string.Empty;

	[JsonPropertyName("Server_IpAddress")]
	public string? ServerIpAddress { get; set; }

	[JsonPropertyName("Server_CPU")]
	public string? ServerCpu { get; set; }

	[JsonPropertyName("Server_Hard_Disk_Drive")]
	public string? ServerHardDiskDrive { get; set; }

	[JsonPropertyName("Server_RAM")]
	public string? ServerRam { get; set; }

	[JsonPropertyName("Server_NIC")]
	public string? ServerNic { get; set; }

	[JsonPropertyName("Server_NETWORK")]
	public string? ServerNetwork { get; set; }

	[JsonPropertyName("Server_RAID_LEVEL")]
	public string? ServerRaidLevel { get; set; }

	[JsonPropertyName("Server_RAID_CARD")]
	public string? ServerRaidCard { get; set; }

	[JsonPropertyName("Server_BACKUP_STATE")]
	public bool? ServerBackupState { get; set; }

	[JsonPropertyName("Server_BACKUP_DETAILS")]
	public string? ServerBackupDetails { get; set; }

	[JsonPropertyName("Server_OPERATING_SYSTEM")]
	public string? ServerOperatingSystem { get; set; }

	[JsonPropertyName("Server_SERVICE_PACK")]
	public string? ServerServicePack { get; set; }

	[JsonPropertyName("Server_INSTALLED_APPLICATIONS")]
	public string? ServerInstalledApplications { get; set; }

	[JsonPropertyName("Server_PATCHES")]
	public string? ServerPatches { get; set; }

	[JsonPropertyName("Network_IpAddress")]
	public string? NetworkIpAddress { get; set; }

	[JsonPropertyName("Network_SUBNET_MASK")]
	public string? NetworkSubnetMask { get; set; }

	[JsonPropertyName("Network_GATEWAY")]
	public string? NetworkGateway { get; set; }

	[JsonPropertyName("Network_NO_OF_SLOTS")]
	public string? NetworkSlotCount { get; set; }

	[JsonPropertyName("Network_SLOT_NUMBERS")]
	public string? NetworkSlotNumbers { get; set; }

	[JsonPropertyName("Network_PORTS")]
	public string? NetworkPorts { get; set; }

	[JsonPropertyName("Network_CARD_TYPE")]
	public string? NetworkCardType { get; set; }

	[JsonPropertyName("Network_VLAN")]
	public string? NetworkVlan { get; set; }

	[JsonPropertyName("Network_FLASH_MEMORY")]
	public string? NetworkFlashMemory { get; set; }

	[JsonPropertyName("Network_DRAM_MEMORY")]
	public string? NetworkDramMemory { get; set; }

	[JsonPropertyName("Network_IOS_SOFTWARE")]
	public string? NetworkIosSoftware { get; set; }

	[JsonPropertyName("Network_ACCESS_LIST")]
	public string? NetworkAccessList { get; set; }

	[JsonPropertyName("Network_ROUTES")]
	public string? NetworkRoutes { get; set; }

	[JsonPropertyName("Network_A_END_DESCRIPTION")]
	public string? NetworkAEndDescription { get; set; }

	[JsonPropertyName("Network_A_END_IP_ADDRESS")]
	public string? NetworkAEndIpAddress { get; set; }

	[JsonPropertyName("Network_B_END_DESCTIPTION")]
	public string? NetworkBEndDescription { get; set; }

	[JsonPropertyName("Network_B_END_IP_ADDRESS")]
	public string? NetworkBEndIpAddress { get; set; }

	[JsonPropertyName("Network_CIRCUIT_ID")]
	public string? NetworkCircuitId { get; set; }
}