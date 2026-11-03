using Microsoft.Extensions.Logging;

namespace SymphonyAi.Summit.Api;

public class SummitClientOptions
{
	public required Uri BaseUri { get; set; }

	public string ApiEndpoint { get; set; } = "api_integration";

	public Uri? CmdbBaseUri { get; set; }

	public Uri? ReportingBaseUri { get; set; }

	public required string ApiKey { get; set; }

	public JsonMissingMemberHandling JsonMissingMemberHandling { get; set; }

	public LogLevel JsonMissingMemberResponseLogLevel { get; set; } = LogLevel.Warning;

	public Action<Type, Exception, string>? JsonMissingMemberAction { get; set; }

	/// <summary>
	/// When true, the client refuses every request other than a known read operation, before sending it.
	/// </summary>
	public bool IsReadOnly { get; set; }
}