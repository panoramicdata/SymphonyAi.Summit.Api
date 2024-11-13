using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SymphonyAi.Summit.Api;
internal class CustomHttpClientHandler(string apiKey, ILogger logger) : HttpClientHandler
{
	private readonly string _apiKey = apiKey;
	private readonly ILogger _logger = logger;
	private AuthResponse? _reportingAuthResponse;
	private readonly Regex _reportingPathRegex = new("^/api_report/");

	protected override async Task<HttpResponseMessage> SendAsync(
		HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		// Reporting API paths require a bearer token
		if (_reportingPathRegex.IsMatch(request.RequestUri!.AbsolutePath))
		{
			if (_reportingAuthResponse is null || _reportingAuthResponse.ExpiresAt < DateTimeOffset.UtcNow)
			{
				_reportingAuthResponse = await GetReportingBearerTokenAsync(
					request.RequestUri.Scheme,
					request.RequestUri.Host,
					_apiKey,
					cancellationToken
				)
					.ConfigureAwait(false)
					?? throw new InvalidOperationException("Invalid request.");
			}

			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _reportingAuthResponse.Token);
		}
		else
		{
			request.Headers.Add("apikey", _apiKey);
		}

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

	private static async Task<AuthResponse> GetReportingBearerTokenAsync(
		string scheme,
		string host,
		string apiKey,
		CancellationToken cancellationToken
	)
	{
		using var httpClient = new HttpClient();
		var request = new HttpRequestMessage(HttpMethod.Get, $"{scheme}://{host}/api_report/api/GenerateToken");
		request.Headers.Add("Apikey", apiKey);

		var response = await httpClient
			.SendAsync(request, cancellationToken)
			.ConfigureAwait(false);

		var authResponse = await response
			.Content
			.ReadFromJsonAsync<AuthResponse>(new JsonSerializerOptions(), cancellationToken)
			.ConfigureAwait(false)
			?? throw new InvalidOperationException("Invalid auth response.");

		// Remove 5 seconds from the expiration time to account for clock skew
		authResponse.ExpiresAt = DateTimeOffset
			.UtcNow
			.AddSeconds(authResponse.ExpireInSecs)
			.AddSeconds(-5);

		return authResponse;
	}
}