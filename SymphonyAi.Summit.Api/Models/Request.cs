using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public abstract class Request(string serviceName)
{
	[JsonPropertyName("ServiceName")]
	public string ServiceName { get; set; } = serviceName;
}