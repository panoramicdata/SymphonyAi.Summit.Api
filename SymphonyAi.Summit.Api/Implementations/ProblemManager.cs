using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Interfaces;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class ProblemManager : Manager, IProblems
{
	private readonly JsonSerializerOptions _jsonSerializerOptions;
	private readonly ILogger _logger;

	public ProblemManager(
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
