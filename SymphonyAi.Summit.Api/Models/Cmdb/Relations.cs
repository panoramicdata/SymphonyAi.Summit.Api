using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class Relations
{

	[JsonPropertyName("ChangeRequestMgmt")]
	public ChangeRequestManagement? ChangeRequestManagement { get; set; }

	[JsonPropertyName("IncidentMgmt")]
	public IncidentManagementSubrootOnly? IncidentManagement { get; set; }

	[JsonPropertyName("ProblemMgmt")]
	public ProblemManagement? ProblemManagement { get; set; }

	[JsonPropertyName("ServiceCatalogMgmt")]
	public ServiceCatalogManagement? ServiceCatalogManagement { get; set; }

	[JsonPropertyName("ServiceMgmt")]
	public ServiceManagement? ServiceManagement { get; set; }
}
