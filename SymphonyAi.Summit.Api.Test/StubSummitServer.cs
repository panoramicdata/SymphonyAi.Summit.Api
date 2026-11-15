using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SymphonyAi.Summit.Api.Test;

public sealed class StubSummitServer : IDisposable
{
	private readonly HttpListener _listener = new();
	private readonly Func<string, string, string> _responder;
	private readonly List<RecordedRequest> _received = [];
	private readonly Task _serving;

	public StubSummitServer(Func<string, string, string> responder)
	{
		_responder = responder;
		var probe = new TcpListener(IPAddress.Loopback, 0);
		probe.Start();
		var port = ((IPEndPoint)probe.LocalEndpoint).Port;
		probe.Stop();
		Address = new Uri($"http://127.0.0.1:{port}/");
		_listener.Prefixes.Add(Address.AbsoluteUri);
		_listener.Start();
		_serving = Task.Run(ServeAsync);
	}

	public Uri Address { get; }

	public IReadOnlyList<RecordedRequest> Received
	{
		get
		{
			lock (_received)
			{
				return [.. _received];
			}
		}
	}

	public void Dispose()
	{
		_listener.Close();
		_serving.GetAwaiter().GetResult();
	}

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

			using var reader = new StreamReader(context.Request.InputStream);
			var body = await reader.ReadToEndAsync();
			var path = context.Request.Url!.AbsolutePath;
			lock (_received)
			{
				_received.Add(new RecordedRequest(context.Request.HttpMethod, path, context.Request.Url.Query, body, context.Request.Headers["apikey"]));
			}

			var bytes = Encoding.UTF8.GetBytes(_responder(path, body));
			context.Response.ContentType = "application/json";
			context.Response.ContentLength64 = bytes.Length;
			await context.Response.OutputStream.WriteAsync(bytes);
			context.Response.Close();
		}
	}
}

public sealed record RecordedRequest(string Method, string Path, string Query, string Body, string? ApiKeyHeader);
