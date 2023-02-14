using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Interfaces;

namespace SymphonyAi.Summit.Api.Implementations;

internal class ServiceRequestManager : Manager, IServiceRequests
{
	private readonly ILogger _logger;

	public ServiceRequestManager(HttpClient httpClient, string apiKey, ILogger logger)
		: base(httpClient, apiKey)
	{
		_logger = logger;
	}
}
