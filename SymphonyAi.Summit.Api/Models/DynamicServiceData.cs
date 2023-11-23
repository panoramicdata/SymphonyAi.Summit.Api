using Newtonsoft.Json;
using SymphonyAi.Summit.Api.Converters;
using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

[JsonObject(MemberSerialization = MemberSerialization.OptOut)]
public class DynamicServiceData
{
	[JsonPropertyName("InputString")]
	[Newtonsoft.Json.JsonConverter(typeof(RawStringConverter))]
	public object? Payload { get; set; }
}