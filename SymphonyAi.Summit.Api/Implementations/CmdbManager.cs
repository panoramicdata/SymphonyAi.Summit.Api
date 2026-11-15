using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Interfaces;
using SymphonyAi.Summit.Api.Models.Cmdb;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class CmdbManager(
	HttpClient httpClient,
	string apiKey,
	string apiIntegrationSubUrl,
	JsonSerializerOptions jsonSerializerOptions,
	ILogger logger) : Manager(
		httpClient,
		apiKey,
		apiIntegrationSubUrl,
		jsonSerializerOptions,
		logger), ICmdb
{
	public Task<CmdbCreateOrUpdateCiResponse> CreateCiAsync(
		CmdbCreateCiRequest request,
		CancellationToken cancellationToken)
		=> SendAsync<CmdbCreateOrUpdateCiResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);

	public Task<CmdbCreateOrUpdateCiResponse> UpdateCiAsync(
		CmdbUpdateCiRequest request,
		CancellationToken cancellationToken)
		=> SendAsync<CmdbCreateOrUpdateCiResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);

	public Task<CmdbCiResponse> GetCiAsync(
		CmdbCiRequest request,
		CancellationToken cancellationToken)
		=> SendAsync<CmdbCiResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);

	public Task<CmdbQueryResponse> GetCisAsync(
		CmdbQueryRequest request,
		CancellationToken cancellationToken)
		=> SendAsync<CmdbQueryResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);

	public Task<CmdbQueryResponse> GetCis2Async(
		CmdbQuery2Request request,
		CancellationToken cancellationToken)
		=> SendAsync<CmdbQueryResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);

	public Task<CmdbCustomersResponse> GetCustomersAsync(
		CmdbCustomersRequest request,
		CancellationToken cancellationToken)
		=> throw new NotSupportedException();

	public Task<CmdbCreateRelationshipResponse> CreateRelationshipAsync(
		CmdbCreateRelationshipRequest request,
		CancellationToken cancellationToken)
		=> SendAsync<CmdbCreateRelationshipResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);

	public Task<CmdbDeleteRelationshipResponse> DeleteRelationshipAsync(
		CmdbDeleteRelationshipRequest request,
		CancellationToken cancellationToken)
		=> SendAsync<CmdbDeleteRelationshipResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);

	public Task<CmdbGetRelationshipsQueryResponse> GetRelationshipsAsync(
		CmdbRelationshipQueryRequest request,
		CancellationToken cancellationToken)
		=> SendAsync<CmdbGetRelationshipsQueryResponse>(request, request.CommonParameters.ProxyDetails, cancellationToken);
}
