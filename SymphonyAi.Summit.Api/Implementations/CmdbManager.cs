using SymphonyAi.Summit.Api.Exceptions;
using SymphonyAi.Summit.Api.Interfaces;
using SymphonyAi.Summit.Api.Models.Cmdb;
using System.Net.Http.Json;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class CmdbManager : Manager, ICmdb
{
	private readonly ILogger _logger;

	public CmdbManager(HttpClient httpClient, string apiKey, ILogger logger)
		: base(httpClient, apiKey)
	{
		_logger = logger;
	}

	public Task<CmdbQueryResponse> GetCisAsync(
		CmdbQueryRequest request,
		CancellationToken cancellationToken)
		=> GetAsync<CmdbQueryRequest, CmdbQueryResponse>(request, cancellationToken);


	private async Task<TResponse> GetAsync<TRequest, TResponse>(
	TRequest request,
	CancellationToken cancellationToken
) where TRequest : CmdbQueryRequest
	{
		request.CommonParameters.ApiKey = ApiKey;
		//var requestJson = JsonSerializer
		//	.Serialize(request);
		var response = await HttpClient
			.PostAsJsonAsync(string.Empty, request, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull }, cancellationToken);
		var responseString = await response
			.Content
			.ReadAsStringAsync(cancellationToken);
		_logger.LogDebug(responseString);
		var returnValue = await response
			.Content
			.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {typeof(TResponse).Name}");
		return returnValue;
	}
}
