using SymphonyAi.Summit.Api.Models.Cmdb;

namespace SymphonyAi.Summit.Api.Interfaces;

/// <summary>
/// CMDB interface
/// </summary>
public interface ICmdb
{
	Task<CmdbQueryResponse> GetCisAsync(
		CmdbQueryRequest request,
		CancellationToken cancellationToken);
}
