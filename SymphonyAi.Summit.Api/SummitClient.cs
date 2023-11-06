using Microsoft.Extensions.Logging;
using Refit;
using SymphonyAi.Summit.Api.Implementations;
using SymphonyAi.Summit.Api.Interfaces;
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
		_httpClient = new HttpClient(new CustomHttpClientHandler(summitClientOptions.ApiKey, logger), true)
		{
			BaseAddress = new Uri(baseUri.ToString()),
		};

		var apiIntegrationSubUrl = baseUri.PathAndQuery == "/"
			? "api_integration"
			: baseUri.PathAndQuery;

		var reportingBaseUri = summitClientOptions.ReportingBaseUri ?? summitClientOptions.BaseUri;
		_reportingHttpClient = new HttpClient(new CustomHttpClientHandler(summitClientOptions.ApiKey, logger), true)
		{
			BaseAddress = new Uri(reportingBaseUri.ToString()),
		};

		var _refitSettings = new RefitSettings
		{
			ContentSerializer = new CustomNewtonsoftJsonContentSerializer(summitClientOptions, logger)
		};

		var jsonSerializerOptions = new JsonSerializerOptions
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
#if DEBUG
			WriteIndented = true
#else
			WriteIndented = false
#endif
		};

		Attachments = new AttachmentManager(
			_httpClient,
			summitClientOptions.ApiKey,
			apiIntegrationSubUrl,
			jsonSerializerOptions,
			logger
			);

		Cmdb = new CmdbManager(
			_httpClient,
			summitClientOptions.ApiKey,
			apiIntegrationSubUrl,
			jsonSerializerOptions,
			logger);

		Incidents = new IncidentManager(
			_httpClient,
			summitClientOptions.ApiKey,
			apiIntegrationSubUrl,
			jsonSerializerOptions,
			logger);

		Problems = new ProblemManager(
			_httpClient,
			summitClientOptions.ApiKey,
			apiIntegrationSubUrl,
			jsonSerializerOptions,
			logger);

		Reports = RestService.For<IReports>(
			_reportingHttpClient,
			_refitSettings);

		ServiceRequests = new ServiceRequestManager(
			_httpClient,
			summitClientOptions.ApiKey,
			apiIntegrationSubUrl,
			jsonSerializerOptions,
			logger);
	}

	public IAttachments Attachments { get; }

	public ICmdb Cmdb { get; }

	public IIncidents Incidents { get; }

	public IProblems Problems { get; }

	public IReports Reports { get; }

	public IServiceRequests ServiceRequests { get; }

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