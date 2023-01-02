using Divergic.Logging.Xunit;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Xunit.Abstractions;

namespace SymphonyAi.Summit.Api.Test
{
	public abstract class TestBase
	{
		public ICacheLogger Logger { get; }
		public SummitClient SummitClient { get; }
		public string Instance { get; }

		protected TestBase(ITestOutputHelper testOutputHelper)
		{
			Logger = testOutputHelper.BuildLogger();
			var configuration = new ConfigurationBuilder()
				.AddUserSecrets<TestBase>()
				.Build();

			SummitClient = new SummitClient(new SummitClientOptions
			{
				BaseUri = new Uri(GetConfig(configuration, "BaseUri")),
				ApiKey = GetConfig(configuration, "ApiKey")
			});
			Instance = GetConfig(configuration, "Instance");
		}

		private static string GetConfig(IConfigurationRoot configuration, string key)
			=> configuration[key] ?? throw new ConfigurationErrorsException("ApiKey not found");
	}
}