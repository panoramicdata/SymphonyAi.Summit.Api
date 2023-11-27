using FluentAssertions;
using SymphonyAi.Summit.Api.Test.Models;
using Xunit.Abstractions;

namespace SymphonyAi.Summit.Api.Test;

public class DynamicServiceTests : TestBase
{
	public DynamicServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
	}

	[Fact]
	public async Task GetIncidentBySymptom_RequestKnownSymptom_GetIncidentsInResponse()
	{
		var request = new GetIncidentIdsBySymptomRequest { Symptom = "LMD5582665" };

		var response = await SummitClient
			.DynamicServices
			.GetDynamicServiceResultAsync<GetIncidentIdsBySymptomRequest, GetIncidentIdsBySymptomResponse>(
				"DWS_IM_GetIncidentIDBySymptom", request, CancellationToken.None);

		response.Should().NotBeNull();
		response!.Should().HaveCount(1);
	}
}
