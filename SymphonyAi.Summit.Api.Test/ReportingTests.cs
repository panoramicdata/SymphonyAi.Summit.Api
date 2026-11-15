﻿using AwesomeAssertions;
using SymphonyAi.Summit.Api.Models.Reporting;

namespace SymphonyAi.Summit.Api.Test;

[Trait("Category", "Integration")]
public class ReportingTests(ITestOutputHelper testOutputHelper) : TestBase(testOutputHelper)
{
	private static void AssertSuccessfulPage(DataPage dataPage)
	{
		dataPage.Status.Message.Should().BeEmpty();
		dataPage.Status.Value.Should().Be("success");
		dataPage.Results.Should().NotBeNullOrEmpty();
	}

	private static void AssertAllHaveTextAndValue(List<TextValuePair> schema)
		=> schema.Should().AllSatisfy(item =>
		{
			item.Text.Should().NotBeNullOrWhiteSpace();
			item.Value.Should().NotBeNullOrWhiteSpace();
		});

	private async Task AssertQuerySucceedsAsync(DataQuery query)
		=> AssertSuccessfulPage(await SummitClient
			.Reports
			.GetTableDataAsync(query, CancellationToken.None));

	[Fact]
	public async Task HealthCheck_Succeeds()
	{
		var response = await SummitClient
			.Reports
			.HealthCheckAsync(CancellationToken.None);

		response.Should().Be("\"Good\"");
	}

	[Fact]
	public async Task GetDnsSchema_Succeeds()
	{
		var response = await SummitClient
			.Reports
			.GetDnsSchemaAsync(CancellationToken.None);

		response.Should().NotBeNullOrEmpty();
		AssertAllHaveTextAndValue(response);
	}

	[Fact]
	public async Task GetTableSchema_Succeeds()
	{
		var dnsSchema = await SummitClient
			.Reports
			.GetDnsSchemaAsync(CancellationToken.None);

		var tableSchema = await SummitClient
			.Reports
			.GetTableSchemaAsync(dnsSchema[0].Text, CancellationToken.None);

		tableSchema.Should().NotBeNullOrEmpty();
		dnsSchema.Select(d => d.Text).Should().NotBeSameAs(tableSchema.Select(d => d.Text));
		AssertAllHaveTextAndValue(tableSchema);
	}

	[Fact]
	public async Task GetData_Succeeds()
	{
		var dnsSchema = await SummitClient
			.Reports
			.GetDnsSchemaAsync(CancellationToken.None);

		var dataPage = await SummitClient
			.Reports
			.GetTableDataAsync(dnsSchema[0].Text, 10000, CancellationToken.None);

		dataPage.Results.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public Task GetDataViaQuery_Succeeds()
		=> AssertQuerySucceedsAsync(new DataQuery
		{
			Table = "CMDB_RPT_DN_CMDBMaster",
			Columns = "[Configuration Item Id],[Classification],[Serial No],[Configuration Information Status],[Create Date],[Sup Function Name], [Life Cycle Status]",
			Filters = "[Configuration Information Status] IN ('Production')"
		});

	[Fact]
	public Task GetDataViaStructuredQuery_Succeeds()
		=> AssertQuerySucceedsAsync(new StructuredDataQuery(new StructuredDataQueryParameters
		{
			DataSource = "IM_RPT_DN_TicketMaster_Vw",
			Columns = ["Ticket ID", "Description", "Status"],
			Filters =
			[
				new MultiValueStringFilter("Status", MultiValueFilterOperators.In, ["Open", "Reopened", "New", "Assigned", "In-Progress", "Pending"])
			]
		}));

	[Fact]
	public Task GetDataViaRawSqlQuery_Succeeds()
		=> AssertQuerySucceedsAsync(new RawSqlDataQuery("SELECT top 10 [Configuration Item Id], [Classification], [Serial No], [Configuration Information Status] FROM CMDB_RPT_DN_CMDBMaster WITH (NOLOCK) where [Configuration Information Status] IN ('Production')"));
}
