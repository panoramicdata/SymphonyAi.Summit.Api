using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbServerDetailsSubroot
{
	[JsonPropertyName("Backup_Details")]
	public string BackupDetails { get; set; }

	[JsonPropertyName("Backup_State")]
	public string BackupState { get; set; }

	[JsonPropertyName("Configuration_Item_Id")]
	public string ConfigurationItemId { get; set; }

	[JsonPropertyName("CPU")]
	public string Cpu { get; set; }

	[JsonPropertyName("Hard_Disk_Drive")]
	public string HardDiskDrive { get; set; }

	[JsonPropertyName("Network")]
	public string Network { get; set; }

	[JsonPropertyName("NIC")]
	public string Nic { get; set; }

	[JsonPropertyName("Operating_System")]
	public string OperatingSystem { get; set; }

	[JsonPropertyName("Org_Id")]
	public string OrgId { get; set; }

	[JsonPropertyName("Patches")]
	public string Patches { get; set; }

	[JsonPropertyName("RAID_Card")]
	public string RaidCard { get; set; }

	[JsonPropertyName("RAM")]
	public string Ram { get; set; }

	[JsonPropertyName("Service_Pack")]
	public string ServicePack { get; set; }
}
