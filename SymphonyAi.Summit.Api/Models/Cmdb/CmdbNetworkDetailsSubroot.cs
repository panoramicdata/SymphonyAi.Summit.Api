using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbNetworkDetailsSubroot
{
	[JsonPropertyName("A_End_Description")]
	public string AEndDescription { get; set; } = string.Empty;

	[JsonPropertyName("A_End_IP_Address")]
	public string AEndIpAddress { get; set; } = string.Empty;

	[JsonPropertyName("Access_List")]
	public string AccessList { get; set; } = string.Empty;

	[JsonPropertyName("B_End_Description")]
	public string BEndDescription { get; set; } = string.Empty;

	[JsonPropertyName("B_End_IP_Address")]
	public string BEndIpAddress { get; set; } = string.Empty;

	[JsonPropertyName("Card_Type")]
	public string CardType { get; set; } = string.Empty;

	[JsonPropertyName("Circuit_Id")]
	public string CircuitId { get; set; } = string.Empty;

	[JsonPropertyName("Configuration_Item_Id")]
	public string ConfigurationItemId { get; set; } = string.Empty;

	[JsonPropertyName("DRAM_Memory")]
	public string DramMemory { get; set; } = string.Empty;

	[JsonPropertyName("Flash_Memory")]
	public string FlashMemory { get; set; } = string.Empty;

	[JsonPropertyName("Gateway")]
	public string Gateway { get; set; } = string.Empty;

	[JsonPropertyName("IOS_Software")]
	public string IosSoftware { get; set; } = string.Empty;

	[JsonPropertyName("IP_Address")]
	public string IpAddress { get; set; } = string.Empty;

	[JsonPropertyName("No_Of_Slots")]
	public string SlotCount { get; set; } = string.Empty;

	[JsonPropertyName("Org_Id")]
	public string OrgId { get; set; } = string.Empty;

	[JsonPropertyName("Ports")]
	public string Ports { get; set; } = string.Empty;

	[JsonPropertyName("Routes")]
	public string Routes { get; set; } = string.Empty;

	[JsonPropertyName("Slot_Numbers")]
	public string SlotNumbers { get; set; } = string.Empty;

	[JsonPropertyName("Subnet_Mask")]
	public string SubnetMask { get; set; } = string.Empty;

	[JsonPropertyName("VLAN")]
	public string Vlan { get; set; } = string.Empty;
}
