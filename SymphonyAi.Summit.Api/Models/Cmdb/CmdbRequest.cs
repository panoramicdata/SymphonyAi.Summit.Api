namespace SymphonyAi.Summit.Api.Models.Cmdb;

public abstract class CmdbRequest(string serviceName) : Request($"CMDB_{serviceName}")
{
}