using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Interfaces;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class AttachmentManager : Manager, IAttachments
{
	private readonly JsonSerializerOptions _jsonSerializerOptions;
	private readonly ILogger _logger;

	public AttachmentManager(
		HttpClient httpClient,
		string apiKey,
		JsonSerializerOptions jsonSerializerOptions,
		ILogger logger)
		: base(httpClient, apiKey)
	{
		_jsonSerializerOptions = jsonSerializerOptions;
		_logger = logger;
	}
}
