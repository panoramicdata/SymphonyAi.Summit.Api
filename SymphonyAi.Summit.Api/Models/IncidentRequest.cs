using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public abstract class IncidentRequest<TCommonParameters> : Request, IIncidentRequest where TCommonParameters : CommonParametersBase, new()
{
	public IncidentRequest(string incidentServiceName) : base("IM_" + incidentServiceName)
	{
	}

	[JsonPropertyName("objCommonParameters")]
	public TCommonParameters CommonParameters { get; set; } = new TCommonParameters();

	ICommonParameters IIncidentRequest.CommonParameters => CommonParameters;
}