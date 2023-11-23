using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class DynamicServiceParameters<TPayload> : CommonParametersBase where TPayload : class
{
	public DynamicServiceParameters(string dynamicServiceName, TPayload payload)
	{
		ServiceName = dynamicServiceName;
		DynamicServiceData = new()
		{
			Payload = payload
		};
	}

	[JsonPropertyName("ServiceName")]
	public string ServiceName { get; }

	[JsonPropertyName("objDynamicWebService")]
	public DynamicServiceData DynamicServiceData { get; set; }
}
