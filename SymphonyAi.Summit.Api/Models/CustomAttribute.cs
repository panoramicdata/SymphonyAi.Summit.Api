using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class CustomAttribute
{

	[JsonPropertyName("ID")]
	public int Id { get; set; }

	[JsonPropertyName("Incident_ID")]
	public int IncidentId { get; set; }

	[JsonPropertyName("Group_Name")]
	public required string GroupName { get; set; }

	[JsonPropertyName("IM_CtAttribute_ID")]
	public int IncidentManagementCtAttributeId { get; set; }

	[JsonPropertyName("SR_CtAttribute_Name")]
	public required string ServiceRequestCtAttributeName { get; set; }

	[JsonPropertyName("AttributeText")]
	public required string AttributeText { get; set; }
}
