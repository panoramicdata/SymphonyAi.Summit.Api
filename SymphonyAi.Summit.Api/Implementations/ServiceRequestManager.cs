using SymphonyAi.Summit.Api.Interfaces;

namespace SymphonyAi.Summit.Api.Implementations;

internal class ServiceRequestManager : Manager, IServiceRequests
{
	public ServiceRequestManager(HttpClient httpClient, string apiKey)
		: base(httpClient, apiKey)
	{
	}
}
