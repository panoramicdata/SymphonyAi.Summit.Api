using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class IncidentManagementSubrootOnly
{

	/// <summary>
	/// Ridiculous.  This is either a <c>List&lt;IncidentManagementSubroot&gt;</c> or an <c>IncidentManagementSubroot</c>, depending on the query response.
	/// </summary>
	[JsonPropertyName("SUBROOT")]
	public object? SubrootObject { get; set; }
}
