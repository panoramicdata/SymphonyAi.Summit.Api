using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Interfaces;

namespace SymphonyAi.Summit.Api.Implementations;

internal class AttachmentManager : Manager, IAttachments
{
	private readonly ILogger _logger;

	public AttachmentManager(HttpClient httpClient, string apiKey, ILogger logger)
		: base(httpClient, apiKey)
	{
		_logger = logger;
	}
}
