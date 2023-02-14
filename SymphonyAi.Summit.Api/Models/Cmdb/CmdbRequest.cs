namespace SymphonyAi.Summit.Api.Models.Cmdb;

public abstract class CmdbRequest : Request
{
	public CmdbRequest(string serviceName) : base($"CMDB_{serviceName}")
	{
	}
}