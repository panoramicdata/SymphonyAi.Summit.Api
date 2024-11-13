using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public abstract class IncidentRequest<TCommonParameters>(string incidentServiceName) : Request("IM_" + incidentServiceName), IIncidentRequest where TCommonParameters : CommonParametersBase, new()
{
	[JsonPropertyName("objCommonParameters")]
	public TCommonParameters CommonParameters { get; set; } = new TCommonParameters();

	ICommonParameters IIncidentRequest.CommonParameters => CommonParameters;
}