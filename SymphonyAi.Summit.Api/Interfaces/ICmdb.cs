using SymphonyAi.Summit.Api.Models.Cmdb;

namespace SymphonyAi.Summit.Api.Interfaces;

/// <summary>
/// CMDB interface
/// </summary>
public interface ICmdb
{
	Task<CmdbCustomersResponse> GetCustomersAsync(
		CmdbCustomersRequest request,
		CancellationToken cancellationToken);

	Task<CmdbCiResponse> GetCiAsync(
		CmdbCiRequest request,
		CancellationToken cancellationToken);

	Task<CmdbQueryResponse> GetCisAsync(
		CmdbQueryRequest request,
		CancellationToken cancellationToken);

	Task<CmdbQueryResponse> GetCis2Async(
		CmdbQuery2Request request,
		CancellationToken cancellationToken);

	Task<CmdbCreateOrUpdateCiResponse> CreateCiAsync(
		CmdbCreateCiRequest request,
		CancellationToken cancellationToken);

	Task<CmdbCreateOrUpdateCiResponse> UpdateCiAsync(
		CmdbUpdateCiRequest request,
		CancellationToken cancellationToken);

	Task<CmdbCreateRelationshipResponse> CreateRelationshipAsync(
		CmdbCreateRelationshipRequest request,
		CancellationToken cancellationToken);

	Task<CmdbGetRelationshipsQueryResponse> GetRelationshipsAsync(
		CmdbRelationshipQueryRequest request,
		CancellationToken cancellationToken);

	Task<CmdbDeleteRelationshipResponse> DeleteRelationshipAsync(
		CmdbDeleteRelationshipRequest request,
		CancellationToken cancellationToken);
}
