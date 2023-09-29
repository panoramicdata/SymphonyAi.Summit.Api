﻿using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Interfaces;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class AttachmentManager : Manager, IAttachments
{
	public AttachmentManager(
		HttpClient httpClient,
		string apiKey,
		string apiIntegrationSubUrl,
		JsonSerializerOptions jsonSerializerOptions,
		ILogger logger)
		: base(
			httpClient,
			apiKey,
			apiIntegrationSubUrl,
			jsonSerializerOptions,
			logger)
	{
	}
}
