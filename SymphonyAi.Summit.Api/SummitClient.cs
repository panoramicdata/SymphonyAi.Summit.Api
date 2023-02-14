using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Implementations;
using SymphonyAi.Summit.Api.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api;

public class SummitClient : IDisposable
{
	private bool _disposedValue;
	private readonly HttpClient _httpClient;

	public SummitClient(SummitClientOptions summitClientOptions, ILogger logger)
	{
		_httpClient = new HttpClient
		{
			BaseAddress = new Uri(summitClientOptions.BaseUri + "/REST/Summit_RESTWCF.svc/RESTService/CommonWS_JsonObjCall")
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

		Attachments = new AttachmentManager(_httpClient, summitClientOptions.ApiKey, jsonSerializerOptions, logger);
		Cmdb = new CmdbManager(_httpClient, summitClientOptions.ApiKey, jsonSerializerOptions, logger);
		Incidents = new IncidentManager(_httpClient, summitClientOptions.ApiKey, jsonSerializerOptions, logger);
		Problems = new ProblemManager(_httpClient, summitClientOptions.ApiKey, jsonSerializerOptions, logger);
		ServiceRequests = new ServiceRequestManager(_httpClient, summitClientOptions.ApiKey, jsonSerializerOptions, logger);
	}

	public IAttachments Attachments { get; }

	public ICmdb Cmdb { get; }

	public IIncidents Incidents { get; }

	public IProblems Problems { get; }

	public IServiceRequests ServiceRequests { get; }

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposedValue)
		{
			if (disposing)
			{
				_httpClient.Dispose();
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