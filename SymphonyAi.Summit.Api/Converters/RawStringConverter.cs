using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace SymphonyAi.Summit.Api.Converters;

internal class RawStringConverter : JsonConverter
{
	public override bool CanConvert(Type typeToConvert) => true;

	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
		if (value is null)
		{
			writer.WriteRawValue("");
			return;
		}

		writer.WriteValue(JsonConvert.SerializeObject(value));
	}

	public override bool CanRead => false;

	public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
		=> throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
}