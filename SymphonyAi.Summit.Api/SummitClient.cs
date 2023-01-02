using SymphonyAi.Summit.Api.Implementations;
using SymphonyAi.Summit.Api.Interfaces;

namespace SymphonyAi.Summit.Api;

public class SummitClient : IDisposable
{
	private readonly SummitClientOptions _summitClientOptions;

	private bool _disposedValue;
	private HttpClient _httpClient;

	public SummitClient(SummitClientOptions summitClientOptions)
	{
		_summitClientOptions = summitClientOptions;
		_httpClient = new HttpClient
		{
			BaseAddress = new Uri(_summitClientOptions.BaseUri + "/REST/Summit_RESTWCF.svc/RESTService/CommonWS_JsonObjCall")
		};
		Incidents = new IncidentManager(_httpClient, _summitClientOptions.ApiKey);
	}

	public IIncidents Incidents { get; }

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