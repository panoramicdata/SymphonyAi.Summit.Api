using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public abstract class Request
{
	public Request(string serviceName)
	{
		ServiceName = serviceName;
	}

	[JsonPropertyName("ServiceName")]
	public string ServiceName { get; set; }
}