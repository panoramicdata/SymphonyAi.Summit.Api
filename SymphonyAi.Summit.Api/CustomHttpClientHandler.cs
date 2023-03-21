using Microsoft.Extensions.Logging;

namespace SymphonyAi.Summit.Api;
internal class CustomHttpClientHandler : HttpClientHandler
{
	private readonly ILogger _logger;

	public CustomHttpClientHandler(ILogger logger)
	{
		_logger = logger;
	}

	protected override async Task<HttpResponseMessage> SendAsync(
		HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		_logger.LogDebug(
			"***Request Headers***:\n{Headers}\n***Request Body***:\n{Body}",
			string.Join("\n", request.Headers.Select(h => $"{h.Key} : {string.Join(';', h.Value)}")),
			request.Content is null ? "(null)" : await request.Content.ReadAsStringAsync(cancellationToken)
		);

		var response = await base
			.SendAsync(request, cancellationToken)
			.ConfigureAwait(false);

		_logger.LogDebug(
			"***Response Headers***:\n{Headers}\n***Response Body***:\n{Body}",
			string.Join("\n", response.Headers.Select(h => $"{h.Key} : {string.Join(';', h.Value)}")),
			response.Content is null ? "(null)" : await response.Content.ReadAsStringAsync(cancellationToken)
		);

		return response;
	}
}