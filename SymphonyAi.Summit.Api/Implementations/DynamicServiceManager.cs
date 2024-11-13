using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Exceptions;
using SymphonyAi.Summit.Api.Interfaces;
using SymphonyAi.Summit.Api.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Implementations;

internal class DynamicServiceManager(
	HttpClient httpClient,
	string apiKey, string
		apiIntegrationSubUrl,
	JsonSerializerOptions jsonSerializerOptions,
	ILogger logger) : Manager(
		httpClient,
		apiKey,
		apiIntegrationSubUrl,
		jsonSerializerOptions,
		logger), IDynamicServices
{

	/// <summary>
	/// Make a request to the dynamic service endpoint and return the results
	/// </summary>
	/// <typeparam name="TRequest">The type of the request data</typeparam>
	/// <typeparam name="TResponse">The type of the response data</typeparam>
	/// <param name="dynamicServiceName">The name of the dynamic service being called</param>
	/// <param name="request">The request data required by the service</param>
	/// <param name="cancellationToken">The token used to manage cancellation</param>
	/// <returns>The response data, or null if none was provided</returns>
	/// <exception cref="SummitApiException">The response was not in the expected format</exception>
	public async Task<TResponse?> GetDynamicServiceResultAsync<TRequest, TResponse>(
		string dynamicServiceName,
		TRequest request,
		CancellationToken cancellationToken)
		where TRequest : class
		where TResponse : class
	{
		var wrappedRequest = new DynamicServiceRequest<TRequest>(dynamicServiceName, request);
		wrappedRequest.CommonParameters.ProxyDetails.ApiKey = ApiKey;

		LogRequest(wrappedRequest);

		HttpResponseMessage response;
		try
		{
			response = await HttpClient
				.PostAsJsonAsync(ApiIntegrationSubUrl, wrappedRequest, JsonSerializerOptions, cancellationToken);
		}
		catch (Exception ex)
		{
			throw new SummitApiException($"Call to Summit Api failed; Message: {ex.Message}", ex);
		}

		await LogResponseAsync(response, cancellationToken);

		var dynamicResponse = await response
			.Content
			.ReadFromJsonAsync<DynamicServiceResponse<TResponse>>(cancellationToken: cancellationToken)
			?? throw new SummitApiException($"Error deserializing {typeof(DynamicServiceResponse<TResponse>).Name}");

		if (!string.IsNullOrWhiteSpace(dynamicResponse.Errors))
		{
			throw new SummitApiException($"Dynamic request returned errors: {dynamicResponse.Errors}");
		}

		if (!string.IsNullOrWhiteSpace(dynamicResponse.Message))
		{
			throw new SummitApiException($"Dynamic request returned message: {dynamicResponse.Message}");
		}

		return dynamicResponse.OutputObject?.Results;
	}
}
