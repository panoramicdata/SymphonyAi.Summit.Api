using System.Text.Json;

namespace SymphonyAi.Summit.Api;

/// <summary>
/// Decides whether a request may be sent when the client is read-only.
/// </summary>
/// <remarks>
/// The integration API sends every call as a POST to one URL with the operation named in the body's ServiceName, so a
/// read is recognised by that name. A name that is not listed, including every dynamic service, is refused.
/// </remarks>
internal static class ReadOnlyRequestPolicy
{
	private const string ReportingDataPath = "/api_report/api/getdata";

	private static readonly HashSet<string> _readServiceNames = new(StringComparer.Ordinal)
	{
		"CMDB_GetCIDetails",
		"CMDB_GetCustomerMasterList",
		"CMDB_Query",
		"CMDB_LoadCIRecords",
		"CMDB_GetCIRelationship",
		"IM_GetIncidentList",
		"IM_GetIncidentListwithDetails",
		"IM_GetIncidentDetailsAndChangeHistory"
	};

	public static async Task EnsureAllowedAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (await IsReadAsync(request, cancellationToken).ConfigureAwait(false))
		{
			return;
		}

		throw new InvalidOperationException($"The client is read-only; {request.Method} {request.RequestUri?.AbsolutePath} would change the server.");
	}

	private static async Task<bool> IsReadAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (request.Method == HttpMethod.Get || request.Method == HttpMethod.Head || request.Method == HttpMethod.Options)
		{
			return true;
		}

		if (request.Method != HttpMethod.Post)
		{
			return false;
		}

		if (string.Equals(request.RequestUri?.AbsolutePath, ReportingDataPath, StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}

		var serviceName = await GetServiceNameAsync(request, cancellationToken).ConfigureAwait(false);

		return serviceName is not null && _readServiceNames.Contains(serviceName);
	}

	private static async Task<string?> GetServiceNameAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (request.Content is null)
		{
			return null;
		}

		try
		{
			var body = await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
			using var document = JsonDocument.Parse(body);

			return document.RootElement.TryGetProperty("ServiceName", out var name) && name.ValueKind == JsonValueKind.String
				? name.GetString()
				: null;
		}
		catch (JsonException)
		{
			return null;
		}
	}
}
