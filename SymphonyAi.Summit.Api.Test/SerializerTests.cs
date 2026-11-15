using AwesomeAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using SymphonyAi.Summit.Api.Models.Reporting;

namespace SymphonyAi.Summit.Api.Test;

public class SerializerTests
{
	private const string ValidJson = """[{"text":"T","value":"V"}]""";
	private const string ExtraMemberJson = """[{"text":"T","value":"V","extra":1}]""";

	private static CustomNewtonsoftJsonContentSerializer Create(
		JsonMissingMemberHandling handling,
		LogLevel logLevel = LogLevel.Warning,
		Action<Type, Exception, string>? action = null)
		=> new(
			new SummitClientOptions
			{
				BaseUri = new Uri("http://localhost"),
				ApiKey = "k",
				JsonMissingMemberHandling = handling,
				JsonMissingMemberResponseLogLevel = logLevel,
				JsonMissingMemberAction = action
			},
			NullLogger.Instance);

	private static Task<List<TextValuePair>?> ReadAsync(CustomNewtonsoftJsonContentSerializer serializer, string json)
		=> serializer.FromHttpContentAsync<List<TextValuePair>>(new StringContent(json), TestContext.Current.CancellationToken);

	[Theory]
	[InlineData(JsonMissingMemberHandling.Ignore)]
	[InlineData(JsonMissingMemberHandling.ThrowOnError)]
	[InlineData(JsonMissingMemberHandling.LogWarningOnErrorAndContinue)]
	public async Task FromHttpContent_ValidJson_Deserializes(JsonMissingMemberHandling handling)
	{
		var result = await ReadAsync(Create(handling), ValidJson);

		result.Should().ContainSingle().Which.Should().BeEquivalentTo(new TextValuePair { Text = "T", Value = "V" });
	}

	[Fact]
	public async Task FromHttpContent_Ignore_NeverInvokesAction()
	{
		var calls = 0;

		var result = await ReadAsync(Create(JsonMissingMemberHandling.Ignore, action: (_, _, _) => calls++), ExtraMemberJson);

		result.Should().ContainSingle();
		calls.Should().Be(0);
	}

	[Theory]
	[InlineData(LogLevel.Warning)]
	[InlineData(LogLevel.None)]
	public async Task FromHttpContent_LogWarningAndContinue_InvokesActionAndStillDeserializes(LogLevel logLevel)
	{
		var seen = new List<(Type Type, string Json)>();

		var result = await ReadAsync(
			Create(JsonMissingMemberHandling.LogWarningOnErrorAndContinue, logLevel, (type, _, json) => seen.Add((type, json))),
			ExtraMemberJson);

		result.Should().ContainSingle().Which.Text.Should().Be("T");
		seen.Should().ContainSingle().Which.Json.Should().Be(ExtraMemberJson);
		seen[0].Type.Should().Be<List<TextValuePair>>();
	}

	[Fact]
	public async Task FromHttpContent_ThrowOnError_InvokesActionThenThrows()
	{
		var calls = 0;
		var serializer = Create(JsonMissingMemberHandling.ThrowOnError, action: (_, _, _) => calls++);

		var act = () => ReadAsync(serializer, ExtraMemberJson);

		await act.Should().ThrowAsync<JsonSerializationException>();
		calls.Should().Be(1);
	}

	[Theory]
	[InlineData(JsonMissingMemberHandling.ThrowOnError)]
	[InlineData(JsonMissingMemberHandling.LogWarningOnErrorAndContinue)]
	public async Task FromHttpContent_InvalidJson_ThrowsJsonReaderException(JsonMissingMemberHandling handling)
	{
		var act = () => ReadAsync(Create(handling), "{not json");

		await act.Should().ThrowAsync<JsonReaderException>();
	}

	[Fact]
	public async Task FromHttpContent_UnknownHandling_IsNotSupported()
	{
		var act = () => ReadAsync(Create((JsonMissingMemberHandling)99), ValidJson);

		await act.Should().ThrowAsync<NotSupportedException>();
	}

	[Fact]
	public async Task ToHttpContent_OmitsNullsAndRoundTrips()
	{
		var serializer = Create(JsonMissingMemberHandling.Ignore);

		var content = serializer.ToHttpContent(new { Name = "x", Missing = (string?)null });
		var json = await content.ReadAsStringAsync(TestContext.Current.CancellationToken);

		json.Should().Be("""{"Name":"x"}""");
	}

	[Fact]
	public void GetFieldNameForProperty_UsesJsonPropertyAttribute()
	{
		var serializer = Create(JsonMissingMemberHandling.Ignore);

		serializer.GetFieldNameForProperty(typeof(Named).GetProperty(nameof(Named.Value))!).Should().Be("renamed");
	}

	private sealed class Named
	{
		[JsonProperty("renamed")]
		public string Value { get; set; } = string.Empty;
	}
}
