using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

internal class DynamicServiceRequest<TPayload> : Request, IDynamicResultRequest where TPayload : class
{
	private DynamicServiceParameters<TPayload> _commonParameters;

	public DynamicServiceRequest(string dynamicServiceName, TPayload payload) : base("ADM_Get_DynamicWebServiceResult")
	{
		_commonParameters = new DynamicServiceParameters<TPayload>(dynamicServiceName, payload);
	}

	[JsonPropertyName("objCommonParameters")]
	public DynamicServiceParameters<TPayload> CommonParameters
	{
		get => _commonParameters;
		set
		{
			ArgumentNullException.ThrowIfNull(value);
			_commonParameters = value;
		}
	}

	ICommonParameters IDynamicResultRequest.CommonParameters => CommonParameters;
}
