using System.Text.Json;
using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Converters;

internal class RawStringConverter : JsonConverter<object>
{
	private static readonly JsonSerializerOptions _rawOptions = new() { WriteIndented = false };
	public override bool CanConvert(Type typeToConvert) => true;

	public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions serializerOptions)
	{
		if (value is null)
		{
			writer.WriteRawValue("");
			return;
		}

		var jsonPayload = JsonSerializer.Serialize(value, typeof(object), _rawOptions);
		writer.WriteStringValue(jsonPayload);
	}

	public override object Read(ref Utf8JsonReader reader, Type objectType, JsonSerializerOptions serializerOptions)
		=> throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
}