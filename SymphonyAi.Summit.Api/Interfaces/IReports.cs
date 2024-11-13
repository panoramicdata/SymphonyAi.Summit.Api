using Refit;
using SymphonyAi.Summit.Api.Models.Reporting;

namespace SymphonyAi.Summit.Api.Interfaces;
public interface IReports
{
	/// <summary>
	/// Return the system health, e.g. "Good".
	/// </summary>
	[Get("/api_report/api/health")]
	Task<string> HealthCheckAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Validates the API Key.
	/// Throws an exception if the key is invalid.
	/// Returns "VALID" if the key is valid.
	/// </summary>
	[Get("/api_report/api")]
	Task<string> ValidateApiKeyAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns the DNS Schema
	/// </summary>
	[Get("/api_report/api/getdnschema")]
	Task<List<TextValuePair>> GetDnsSchemaAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Returns the Table Schema
	/// </summary>
	[Get("/api_report/api/getdnschema")]
	Task<List<TextValuePair>> GetTableSchemaAsync(
		[Query] string dataSource,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns Table data
	/// </summary>
	[Get("/api_report/api/getdata")]
	Task<DataPage> GetTableDataAsync(
		[Query] string dataSource,
		[Query] int pageSize,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns Table data
	/// </summary>
	[Post("/api_report/api/getdata")]
	Task<DataPage> GetTableDataAsync(
		[Body] DataQuery dataQuery,
		CancellationToken cancellationToken
		);
}
