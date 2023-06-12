using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class IncidentManagementSubrootOnly
{

	[JsonPropertyName("SUBROOT")]
	public List<IncidentManagementSubroot> Subroot { get; set; }
}
