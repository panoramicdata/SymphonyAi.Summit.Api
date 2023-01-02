using SymphonyAi.Summit.Api.Interfaces;

namespace SymphonyAi.Summit.Api.Implementations;

internal class ProblemManager : Manager, IProblems
{
	public ProblemManager(HttpClient httpClient, string apiKey)
		: base(httpClient, apiKey)
	{
	}
}
