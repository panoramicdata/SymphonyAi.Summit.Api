using Newtonsoft.Json;

namespace SymphonyAi.Summit.Api.Models;

public class DynamicServiceResponseData<TResponse>
{
	[JsonProperty("SUBROOT")]
	public TResponse? Results { get; set; }
}