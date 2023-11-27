using Newtonsoft.Json;

namespace SymphonyAi.Summit.Api.Models;

internal class DynamicServiceResponse<TResponse> : Response
{
	[JsonProperty("OutputObject")]
	public required DynamicServiceResponseData<TResponse>? OutputObject { get; set; }
}