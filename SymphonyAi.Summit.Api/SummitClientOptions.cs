using Microsoft.Extensions.Logging;

namespace SymphonyAi.Summit.Api;

public class SummitClientOptions
{
	public /*required*/ Uri BaseUri { get; set; }
	public /*required*/ string ApiKey { get; set; }

	public JsonMissingMemberHandling JsonMissingMemberHandling { get; set; }

	public LogLevel JsonMissingMemberResponseLogLevel { get; set; } = LogLevel.Warning;
	public Action<Type, Exception, string>? JsonMissingMemberAction { get; set; }
}