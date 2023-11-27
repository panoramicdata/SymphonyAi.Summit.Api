namespace SymphonyAi.Summit.Api.Interfaces;

public interface IDynamicServices
{
	/// <summary>
	/// Gets a response from the dynamic web service.
	/// </summary>
	/// <param name="request">The request payload</param>
	/// <param name="cancellationToken">The token used to manage cancellation</param>
	/// <returns></returns>
	Task<TResponse?> GetDynamicServiceResultAsync<TRequest, TResponse>(
		string dynamicServiceName,
		TRequest request,
		CancellationToken cancellationToken)
		where TRequest : class
		where TResponse : class;
}
