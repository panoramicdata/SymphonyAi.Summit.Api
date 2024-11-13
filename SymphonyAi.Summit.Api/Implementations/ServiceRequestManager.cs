using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Interfaces;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class ServiceRequestManager(
	HttpClient httpClient,
	string apiKey,
	string apiIntegrationSubUrl,
	JsonSerializerOptions jsonSerializerOptions,
	ILogger logger) : Manager(
		httpClient,
		apiKey,
		apiIntegrationSubUrl,
		jsonSerializerOptions,
		logger), IServiceRequests
{
}
