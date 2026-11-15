﻿using AwesomeAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using SymphonyAi.Summit.Api.Exceptions;
using SymphonyAi.Summit.Api.Models;
using SymphonyAi.Summit.Api.Models.Cmdb;

namespace SymphonyAi.Summit.Api.Test;

public sealed class OfflineClientTests
{
	private const string ApiKey = "test-key";
	private const string EmptyObject = """{"Errors":"","Message":"","Input":{},"OutputObject":{"MyTickets":[],"IncidentDetails":{"TicketDetails":[],"ChangeHistory":[],"CustomAttributes":[]}}}""";
	private const string DynamicEnvelopeStart = """{"Errors":"","Message":"","Input":{},""";

	private static StubSummitServer ServerReturning(string json) => new((_, _) => json);

	private static string Compact(string json) => System.Text.RegularExpressions.Regex.Replace(json, @"\s", string.Empty);

	private static SummitClient ClientFor(StubSummitServer server, Action<SummitClientOptions>? configure = null)
	{
		var options = new SummitClientOptions { BaseUri = server.Address, ApiKey = ApiKey };
		configure?.Invoke(options);
		return new SummitClient(options, NullLogger.Instance);
	}

	private static Task<List<string>?> CallDynamicAsync(SummitClient client)
		=> client.DynamicServices.GetDynamicServiceResultAsync<object, List<string>>("MyService", new object(), TestContext.Current.CancellationToken);

	public static IEnumerable<object[]> ServiceCalls()
	{
		yield return Call("CMDB_CreateOrUpdateCIDetails", (c, t) => c.Cmdb.CreateCiAsync(new CmdbCreateCiRequest(), t));
		yield return Call("CMDB_CreateOrUpdateCIDetails", (c, t) => c.Cmdb.UpdateCiAsync(new CmdbUpdateCiRequest(), t));
		yield return Call("CMDB_GetCIDetails", (c, t) => c.Cmdb.GetCiAsync(new CmdbCiRequest(), t));
		yield return Call("CMDB_LoadCIRecords", (c, t) => c.Cmdb.GetCisAsync(new CmdbQueryRequest(), t));
		yield return Call("CMDB_Query", (c, t) => c.Cmdb.GetCis2Async(new CmdbQuery2Request(), t));
		yield return Call("CMDB_GetCIRelationship", (c, t) => c.Cmdb.GetRelationshipsAsync(new CmdbRelationshipQueryRequest(), t));
		yield return Call("CMDB_", (c, t) => c.Cmdb.CreateRelationshipAsync(new CmdbCreateRelationshipRequest(), t));
		yield return Call("CMDB_", (c, t) => c.Cmdb.DeleteRelationshipAsync(new CmdbDeleteRelationshipRequest(), t));
		yield return Call("IM_GetIncidentList", (c, t) => c.Incidents.GetIncidentListAsync(new GetIncidentListRequest(), t));
		yield return Call("IM_GetIncidentListwithDetails", (c, t) => c.Incidents.GetIncidentListDetailsAsync(new GetIncidentListDetailsRequest(), t));
		yield return Call("IM_GetIncidentDetailsAndChangeHistory", (c, t) => c.Incidents.GetIncidentDetailsAndChangeHistoryAsync(new GetIncidentDetailsAndChangeHistoryRequest(), t));
		yield return Call("IM_LogOrUpdateIncident", (c, t) => c.Incidents.CreateOrUpdateIncidentAsync(new CreateOrUpdateIncidentRequest(), t));
	}

	private static object[] Call<T>(string serviceNamePrefix, Func<SummitClient, CancellationToken, Task<T>> call) where T : notnull
		=> [serviceNamePrefix, new Func<SummitClient, CancellationToken, Task<object>>(async (c, t) => await call(c, t))];

	[Theory]
	[MemberData(nameof(ServiceCalls))]
	public async Task ServiceCall_SendsApiKeyAndServiceName(string serviceNamePrefix, Func<SummitClient, CancellationToken, Task<object>> call)
	{
		using var server = ServerReturning(EmptyObject);
		using var client = ClientFor(server);

		var response = await call(client, TestContext.Current.CancellationToken);

		response.Should().NotBeNull();
		var request = server.Received.Should().ContainSingle().Subject;
		request.Method.Should().Be("POST");
		request.ApiKeyHeader.Should().Be(ApiKey);
		Compact(request.Body).Should().Contain($"\"APIKey\":\"{ApiKey}\"");
		Compact(request.Body).Should().Contain($"\"ServiceName\":\"{serviceNamePrefix}");
	}

	[Fact]
	public async Task ServiceCall_NullBody_ThrowsSummitApiExceptionNamingResponseType()
	{
		using var server = ServerReturning("null");
		using var client = ClientFor(server);

		var act = () => client.Cmdb.GetCisAsync(new CmdbQueryRequest(), TestContext.Current.CancellationToken);

		(await act.Should().ThrowAsync<SummitApiException>()).Which.Message.Should().Contain(nameof(CmdbQueryResponse));
	}

	[Fact]
	public async Task GetCustomers_IsNotSupported()
	{
		using var server = ServerReturning(EmptyObject);
		using var client = ClientFor(server);

		var act = () => client.Cmdb.GetCustomersAsync(new CmdbCustomersRequest(), TestContext.Current.CancellationToken);

		await act.Should().ThrowAsync<NotSupportedException>();
		server.Received.Should().BeEmpty();
	}

	[Fact]
	public async Task CreateCi_ParsesOutputFields()
	{
		using var server = ServerReturning("""{"Errors":"","Message":"ok","Output":"Created","OutputID":42}""");
		using var client = ClientFor(server);

		var response = await client.Cmdb.CreateCiAsync(new CmdbCreateCiRequest(), TestContext.Current.CancellationToken);

		response.Output.Should().Be("Created");
		response.OutputId.Should().Be(42);
		response.Message.Should().Be("ok");
	}

	[Fact]
	public async Task DynamicService_ReturnsSubRootResults()
	{
		using var server = ServerReturning(DynamicEnvelopeStart + "\"OutputObject\":{\"SUBROOT\":[\"a\",\"b\"]}}");
		using var client = ClientFor(server);

		var results = await CallDynamicAsync(client);

		results.Should().Equal("a", "b");
		Compact(server.Received.Single().Body).Should().Contain("MyService");
	}

	[Theory]
	[InlineData("""{"Errors":"boom","Message":"","Input":{},"OutputObject":null}""", "errors: boom")]
	[InlineData("""{"Errors":"","Message":"careful","Input":{},"OutputObject":null}""", "message: careful")]
	public async Task DynamicService_ErrorOrMessage_ThrowsSummitApiException(string json, string expected)
	{
		using var server = ServerReturning(json);
		using var client = ClientFor(server);

		var act = () => CallDynamicAsync(client);

		(await act.Should().ThrowAsync<SummitApiException>()).Which.Message.Should().Contain(expected);
	}

	[Fact]
	public async Task DynamicService_NullOutputObject_ReturnsNull()
	{
		using var server = ServerReturning(DynamicEnvelopeStart + "\"OutputObject\":null}");
		using var client = ClientFor(server);

		var results = await CallDynamicAsync(client);

		results.Should().BeNull();
	}

	[Fact]
	public async Task DynamicService_ConnectionFailure_ThrowsSummitApiException()
	{
		var server = ServerReturning(EmptyObject);
		var address = server.Address;
		server.Dispose();
		using var client = new SummitClient(new SummitClientOptions { BaseUri = address, ApiKey = ApiKey }, NullLogger.Instance);

		var act = () => CallDynamicAsync(client);

		(await act.Should().ThrowAsync<SummitApiException>()).Which.Message.Should().Contain("Call to Summit Api failed");
	}
}
