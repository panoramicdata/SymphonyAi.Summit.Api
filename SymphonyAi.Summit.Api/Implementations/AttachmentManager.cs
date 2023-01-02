using SymphonyAi.Summit.Api.Interfaces;

namespace SymphonyAi.Summit.Api.Implementations;

internal class AttachmentManager : Manager, IAttachments
{
	public AttachmentManager(HttpClient httpClient, string apiKey)
		: base(httpClient, apiKey)
	{
	}
}
