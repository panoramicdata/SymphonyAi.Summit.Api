using Divergic.Logging.Xunit;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Configuration;
using Xunit.Abstractions;

namespace SymphonyAi.Summit.Api.Test;

public abstract class TestBase
{
	public ICacheLogger Logger { get; }
	public SummitClient SummitClient { get; }
	public string Instance { get; }
	public int TicketNumber { get; }

	protected TestBase(ITestOutputHelper testOutputHelper)
	{
		Logger = testOutputHelper.BuildLogger();
		var configuration = new ConfigurationBuilder()
			.AddUserSecrets<TestBase>()
			.Build();

		SummitClient = new SummitClient(new SummitClientOptions
		{
			BaseUri = new Uri(GetConfig<string>(configuration, "BaseUri")),
			ApiKey = GetConfig<string>(configuration, "ApiKey")
		});
		Instance = GetConfig<string>(configuration, "Instance");
		TicketNumber = GetConfig<int>(configuration, "TicketNumber");
	}

	private static T GetConfig<T>(IConfigurationRoot configuration, string key)
	{
		var stringValue = configuration[key] ?? throw new ConfigurationErrorsException($"{key} not found in user secrets.");
		var type = typeof(T);

		object? result = Type.GetTypeCode(typeof(T)) switch
		{
			TypeCode.String => stringValue
				?? throw new ConfigurationErrorsException($"{key} not found in user secrets."),
			TypeCode.Int32 => (int.TryParse(stringValue, out var intValue) ? (int?)intValue : null)
				?? throw new ConfigurationErrorsException($"{key} not found in user secrets."),
			_ => throw new NotSupportedException($"Type {type} not supported."),
		};

		return (T)result;
	}

	protected static async Task<T> LoadObjectFromJsonFile<T>(
		string fileNameWithoutExtension,
		CancellationToken cancellationToken
	)
	{
		var fileInfo = new FileInfo($"../../../TestObjects/{fileNameWithoutExtension}.json");
		var json = await File.ReadAllTextAsync(fileInfo.FullName, cancellationToken);
		return JsonConvert.DeserializeObject<T>(json)
			?? throw new FormatException($"File does not contain valid json of type {typeof(T)}");
	}
}