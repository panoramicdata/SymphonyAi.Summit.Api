using AwesomeAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using SymphonyAi.Summit.Api.Exceptions;
using SymphonyAi.Summit.Api.Models;
using SymphonyAi.Summit.Api.Models.Cmdb;
using SymphonyAi.Summit.Api.Models.Reporting;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SymphonyAi.Summit.Api.Test;

/// <summary>
/// <see cref="SummitClientOptions.IsReadOnly"/> needs no Summit tenant, API key or configuration.
/// </summary>
public sealed class ReadOnlyOptionTests : IDisposable
{
	private readonly Uri _address;
	private readonly HttpListener _listener = new();
	private readonly List<string> _received = [];

	public ReadOnlyOptionTests()
	{
		var probe = new TcpListener(IPAddress.Loopback, 0);
		probe.Start();
		var port = ((IPEndPoint)probe.LocalEndpoint).Port;
		probe.Stop();
		_address = new Uri($"http://127.0.0.1:{port}/");
		_listener.Prefixes.Add(_address.AbsoluteUri);
		_listener.Start();
		_ = Task.Run(ServeAsync);
	}

	public void Dispose() => _listener.Close();

	private async Task ServeAsync()
	{
		while (_listener.IsListening)
		{
			HttpListenerContext context;
			try
			{
				context = await _listener.GetContextAsync();
			}
			catch (Exception ex) when (ex is HttpListenerException or ObjectDisposedException)
			{
				return;
			}

			var body = await new StreamReader(context.Request.InputStream).ReadToEndAsync();
			var path = context.Request.Url!.AbsolutePath;
			lock (_received)
			{
				_received.Add($"{context.Request.HttpMethod} {path} {body}");
			}

			var json = path.EndsWith("GenerateToken", StringComparison.OrdinalIgnoreCase)
				? """{"Token":"t","Expire_InSecs":600}"""
				: "{}";
			var bytes = Encoding.UTF8.GetBytes(json);
			context.Response.ContentType = "application/json";
			context.Response.ContentLength64 = bytes.Length;
			await context.Response.OutputStream.WriteAsync(bytes);
			context.Response.Close();
		}
	}

	private SummitClient ClientFor(bool isReadOnly)
		=> new(
			new SummitClientOptions { BaseUri = _address, ApiKey = "not-a-real-key", IsReadOnly = isReadOnly },
			NullLogger.Instance);

	private string[] Received()
	{
		lock (_received)
		{
			return [.. _received];
		}
	}

	private static async Task<Exception?> TryAsync(Func<Task> action)
	{
		try
		{
			await action();
			return null;
		}
		catch (Exception ex)
		{
			return ex;
		}
	}

	private static bool IsRefused(Exception? e)
		=> e is not null && e.ToString().Contains("The client is read-only", StringComparison.Ordinal);

	[Fact]
	public void IsReadOnly_DefaultsToFalse()
		=> new SummitClientOptions { BaseUri = new Uri("http://localhost"), ApiKey = "k" }.IsReadOnly.Should().BeFalse();

	[Fact]
	public async Task ReadOnly_CreateCi_IsRefusedBeforeSending()
	{
		using var client = ClientFor(isReadOnly: true);

		var thrown = await TryAsync(() => client.Cmdb.CreateCiAsync(new CmdbCreateCiRequest(), TestContext.Current.CancellationToken));

		IsRefused(thrown).Should().BeTrue();
		Received().Should().BeEmpty();
	}

	[Fact]
	public async Task ReadOnly_LogOrUpdateIncident_IsRefusedBeforeSending()
	{
		using var client = ClientFor(isReadOnly: true);

		var thrown = await TryAsync(() => client.Incidents.CreateOrUpdateIncidentAsync(new CreateOrUpdateIncidentRequest(), TestContext.Current.CancellationToken));

		IsRefused(thrown).Should().BeTrue();
		Received().Should().BeEmpty();
	}

	[Fact]
	public async Task ReadOnly_DynamicService_IsRefusedBecauseItsEffectIsUnknown()
	{
		using var client = ClientFor(isReadOnly: true);

		var thrown = await TryAsync(() => client.DynamicServices.GetDynamicServiceResultAsync<object, object>("AnyService", new object(), TestContext.Current.CancellationToken));

		thrown.Should().BeOfType<SummitApiException>();
		thrown!.Message.Should().Contain("The client is read-only");
		Received().Should().BeEmpty();
	}

	[Fact]
	public async Task NotReadOnly_CreateCi_IsSent()
	{
		using var client = ClientFor(isReadOnly: false);

		await TryAsync(() => client.Cmdb.CreateCiAsync(new CmdbCreateCiRequest(), TestContext.Current.CancellationToken));

		Received().Should().ContainSingle().Which.Should().Contain("CMDB_CreateOrUpdateCIDetails");
	}

	[Fact]
	public async Task ReadOnly_NamedReadOperation_StillGoesThrough()
	{
		using var client = ClientFor(isReadOnly: true);

		var thrown = await TryAsync(() => client.Cmdb.GetCisAsync(new CmdbQueryRequest(), TestContext.Current.CancellationToken));

		IsRefused(thrown).Should().BeFalse(thrown?.ToString());
		Received().Should().ContainSingle(thrown?.ToString()).Which.Should().Contain("CMDB_LoadCIRecords");
	}

	[Fact]
	public async Task ReadOnly_ReportingDataPost_IsNotRefused()
	{
		using var client = ClientFor(isReadOnly: true);

		var thrown = await TryAsync(() => client.Reports.GetTableDataAsync(new DataQuery { Table = "t" }, TestContext.Current.CancellationToken));

		// The bearer-token fetch that follows the policy check ignores the port, so the failure is a refused connection, not the policy.
		IsRefused(thrown).Should().BeFalse(thrown?.ToString());
		thrown.Should().NotBeNull();
	}
}
