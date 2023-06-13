using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class IncidentManagementSubrootOnly
{

	/// <summary>
	/// Ridiculous.  This is either a List<IncidentManagementSubroot> or a IncidentManagementSubroot, depending on the query response.
	/// </summary>
	[JsonPropertyName("SUBROOT")]
	public object? SubrootObject { get; set; }
}
