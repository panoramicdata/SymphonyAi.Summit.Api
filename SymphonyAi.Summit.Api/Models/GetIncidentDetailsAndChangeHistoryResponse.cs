using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class GetIncidentDetailsAndChangeHistoryResponse : Response
{
	[JsonPropertyName("OutputObject")]
	public /*required*/ IncidentDetailsAndChangeHistoryOutputObject OutputObject { get; set; }
}
