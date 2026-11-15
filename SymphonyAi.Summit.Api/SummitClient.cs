using Microsoft.Extensions.Logging;
using Refit;
using SymphonyAi.Summit.Api.Converters;
using SymphonyAi.Summit.Api.Implementations;
using SymphonyAi.Summit.Api.Interfaces;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api;

public class SummitClient : IDisposable
{
	private bool _disposedValue;
	private readonly HttpClient _httpClient;
	private readonly HttpClient _reportingHttpClient;

	public SummitClient(SummitClientOptions summitClientOptions, ILogger logger)
	{
		// TODO: Remove CmdbBaseUri, this is probably no longer a useful setting
		// The hypothesis is that Cmdb is always on the same URL as everything BUT reporting.
		var baseUri = summitClientOptions.CmdbBaseUri ?? summitClientOptions.BaseUri;
		_httpClient = CreateHttpClient(baseUri, summitClientOptions, logger);

		var apiIntegrationSubUrl = baseUri.PathAndQuery == "/"
			? "api_integration"
			: baseUri.PathAndQuery;

		_reportingHttpClient = CreateHttpClient(summitClientOptions.ReportingBaseUri ?? summitClientOptions.BaseUri, summitClientOptions, logger);

		var refitSettings = new RefitSettings
		{
			ContentSerializer = new CustomNewtonsoftJsonContentSerializer(summitClientOptions, logger)
		};

		var jsonSerializerOptions = CreateJsonSerializerOptions(null);
		var dynamicServiceSerializerOptions = CreateJsonSerializerOptions(new CustomQuoteEncoder());
		var apiKey = summitClientOptions.ApiKey;

		Attachments = new AttachmentManager(_httpClient, apiKey, apiIntegrationSubUrl, jsonSerializerOptions, logger);
		Cmdb = new CmdbManager(_httpClient, apiKey, apiIntegrationSubUrl, jsonSerializerOptions, logger);
		Incidents = new IncidentManager(_httpClient, apiKey, apiIntegrationSubUrl, jsonSerializerOptions, logger);
		Problems = new ProblemManager(_httpClient, apiKey, apiIntegrationSubUrl, jsonSerializerOptions, logger);
		Reports = RestService.For<IReports>(_reportingHttpClient, refitSettings);
		ServiceRequests = new ServiceRequestManager(_httpClient, apiKey, apiIntegrationSubUrl, jsonSerializerOptions, logger);
		DynamicServices = new DynamicServiceManager(_httpClient, apiKey, apiIntegrationSubUrl, dynamicServiceSerializerOptions, logger);
	}

	private static HttpClient CreateHttpClient(Uri baseUri, SummitClientOptions options, ILogger logger)
		=> new(new CustomHttpClientHandler(options.ApiKey, logger, options), true)
		{
			BaseAddress = new Uri(baseUri.ToString()),
		};

	private static JsonSerializerOptions CreateJsonSerializerOptions(JavaScriptEncoder? encoder)
		=> new()
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			Encoder = encoder,
#if DEBUG
			WriteIndented = true
#else
			WriteIndented = false
#endif
		};

	public IAttachments Attachments { get; }

	public ICmdb Cmdb { get; }

	public IIncidents Incidents { get; }

	public IProblems Problems { get; }

	public IReports Reports { get; }

	public IServiceRequests ServiceRequests { get; }

	public IDynamicServices DynamicServices { get; }

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposedValue)
		{
			if (disposing)
			{
				_httpClient.Dispose();
				_reportingHttpClient.Dispose();
			}

			_disposedValue = true;
		}
	}

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}