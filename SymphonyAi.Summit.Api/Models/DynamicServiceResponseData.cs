using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

internal class DynamicServiceResponseData<TResponse>
{
	[JsonPropertyName("SUBROOT")]
	public TResponse? Results { get; set; }
}