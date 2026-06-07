using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

internal class DynamicServiceRequest<TPayload>(string dynamicServiceName, TPayload payload) : Request("ADM_Get_DynamicWebServiceResult"), IDynamicResultRequest where TPayload : class
{
	[JsonPropertyName("objCommonParameters")]
	public DynamicServiceParameters<TPayload> CommonParameters { get; set; } = new(dynamicServiceName, payload);

	ICommonParameters IDynamicResultRequest.CommonParameters => CommonParameters;
}
