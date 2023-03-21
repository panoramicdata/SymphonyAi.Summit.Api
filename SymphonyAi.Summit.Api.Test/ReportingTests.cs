using FluentAssertions;
using SymphonyAi.Summit.Api.Reporting;
using Xunit.Abstractions;

namespace SymphonyAi.Summit.Api.Test;

public class ReportingTests : TestBase
{
	public ReportingTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
	}

	[Fact]
	public async Task HealthCheck_Succeeds()
	{
		var response = await SummitClient
			.Reports
			.HealthCheckAsync(CancellationToken.None);

		response.Should().Be("\"Good\"");
	}

	[Fact]
	public async Task ApiKeyValidation_Succeeds()
	{
		var response = await SummitClient
			.Reports
			.ValidateApiKeyAsync(CancellationToken.None);

		response.Should().Be("\"VALID\"");
	}

	[Fact]
	public async Task GetDnsSchema_Succeeds()
	{
		var response = await SummitClient
			.Reports
			.GetDnsSchemaAsync(CancellationToken.None);

		response.Should().NotBeNullOrEmpty();

		// All the DNS Schema values should have text and value set
		response.Should().AllSatisfy(item =>
		{
			item.Text.Should().NotBeNullOrWhiteSpace();
			item.Value.Should().NotBeNullOrWhiteSpace();
		});
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

		// All the DNS Schema values should have text and value set
		tableSchema.Should().AllSatisfy(item =>
		{
			item.Text.Should().NotBeNullOrWhiteSpace();
			item.Value.Should().NotBeNullOrWhiteSpace();
		});
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
	public async Task GetDataViaQuery_Succeeds()
	{
		var query = new DataQuery
		{
			Table = "CMDB_RPT_DN_CMDBMaster",
			Columns = "[Configuration Item Id],[Classification],[Serial No],[Configuration Information Status],[Create Date],[Sup Function Name], [Life Cycle Status]",
			Filters = "[Configuration Information Status] IN ('Production')"
		};

		var dataPage = await SummitClient
			.Reports
			.GetTableDataAsync(query, CancellationToken.None);

		dataPage.Results.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task GetDataViaRawSqlQuery_Succeeds()
	{
		var query = new RawSqlDataQuery("SELECT top 10 [Configuration Item Id], [Classification], [Serial No], [Configuration Information Status] FROM CMDB_RPT_DN_CMDBMaster WITH (NOLOCK) where [Configuration Information Status] IN ('Production')");

		var dataPage = await SummitClient
			.Reports
			.GetTableDataAsync(query, CancellationToken.None);

		dataPage.Results.Should().NotBeNullOrEmpty();
	}
}