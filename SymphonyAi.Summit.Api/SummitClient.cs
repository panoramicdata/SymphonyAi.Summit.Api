using SymphonyAi.Summit.Api.Implementations;
using SymphonyAi.Summit.Api.Interfaces;

namespace SymphonyAi.Summit.Api;

public class SummitClient : IDisposable
{
	private bool _disposedValue;
	private readonly HttpClient _httpClient;

	public SummitClient(SummitClientOptions summitClientOptions)
	{
		_httpClient = new HttpClient
		{
			BaseAddress = new Uri(summitClientOptions.BaseUri + "/REST/Summit_RESTWCF.svc/RESTService/CommonWS_JsonObjCall")
		};

		Attachments = new AttachmentManager(_httpClient, summitClientOptions.ApiKey);
		Cmdb = new CmdbManager(_httpClient, summitClientOptions.ApiKey);
		Incidents = new IncidentManager(_httpClient, summitClientOptions.ApiKey);
		Problems = new ProblemManager(_httpClient, summitClientOptions.ApiKey);
		ServiceRequests = new ServiceRequestManager(_httpClient, summitClientOptions.ApiKey);
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