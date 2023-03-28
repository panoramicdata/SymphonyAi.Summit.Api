using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public abstract class CommonParametersBase : ICommonParameters
{
	[JsonPropertyName("_ProxyDetails")]
	public ProxyDetails ProxyDetails { get; set; } = new();
}
