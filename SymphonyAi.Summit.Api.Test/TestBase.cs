﻿using Divergic.Logging.Xunit;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Text.Json;
using Xunit.Abstractions;

namespace SymphonyAi.Summit.Api.Test;

public abstract class TestBase
{
	public ICacheLogger Logger { get; }

	public SummitClient SummitClient { get; }

	public string Instance { get; }

	public int TicketNumber { get; }

	public string WorkgroupName { get; }

	public string CustomerName { get; }

	public string OwnerName { get; }

	public string CallerEmailId { get; }

	public string KnownSymptom { get; }

	public string UnknownSymptom { get; }

	protected TestBase(ITestOutputHelper testOutputHelper)
	{
		Logger = testOutputHelper.BuildLogger();
		var configuration = new ConfigurationBuilder()
			.AddUserSecrets<TestBase>()
			.Build();

		var cmdbBaseUriString = GetConfig<string>(configuration, "CmdbBaseUri");
		var reportingUriString = GetConfig<string>(configuration, "ReportingBaseUri");

		SummitClient = new SummitClient(new SummitClientOptions
		{
			BaseUri = new Uri(GetConfig<string>(configuration, "BaseUri")),
			CmdbBaseUri = string.IsNullOrEmpty(cmdbBaseUriString) ? null : new Uri(cmdbBaseUriString),
			ReportingBaseUri = string.IsNullOrEmpty(reportingUriString) ? null : new Uri(reportingUriString),
			ApiKey = GetConfig<string>(configuration, "ApiKey")
		}, Logger);
		Instance = GetConfig<string>(configuration, "Instance");
		TicketNumber = GetConfig<int>(configuration, "TicketNumber");
		WorkgroupName = GetConfig<string>(configuration, "WorkgroupName");
		CallerEmailId = GetConfig<string>(configuration, "CallerEmailId");
		OwnerName = GetConfig<string>(configuration, "OwnerName");
		CustomerName = GetConfig<string>(configuration, "CustomerName");
		KnownSymptom = GetConfig<string>(configuration, "KnownSymptom");
		UnknownSymptom = GetConfig<string>(configuration, "UnknownSymptom");
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
		return JsonSerializer.Deserialize<T>(json)
			?? throw new FormatException($"File does not contain valid json of type {typeof(T)}");
	}
}