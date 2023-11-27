using SymphonyAi.Summit.Api.Converters;
using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

internal class DynamicServiceData
{
	[JsonPropertyName("InputString")]
	[JsonConverter(typeof(RawStringConverter))]
	public object? Payload { get; set; }
}