using SymphonyAi.Summit.Api.Interfaces;

namespace SymphonyAi.Summit.Api.Implementations;

internal class CmdbManager : Manager, ICmdb
{
	public CmdbManager(HttpClient httpClient, string apiKey)
		: base(httpClient, apiKey)
	{
	}
}
