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
		var request = new GetIncidentIdsBySymptomRequest { Symptom = KnownSymptom };

		var response = await SummitClient
			.DynamicServices
			.GetDynamicServiceResultAsync<GetIncidentIdsBySymptomRequest, List<GetIncidentIdsBySymptomResponseData>>(
				"DWS_IM_GetIncidentIDBySymptom", request, CancellationToken.None);

		response.Should().NotBeNull();
		response!.Should().HaveCount(1);
	}

	[Fact]
	public async Task GetIncidentBySymptom_RequestUnknownSymptom_GetEmptyIncidentsListInResponse()
	{
		var request = new GetIncidentIdsBySymptomRequest { Symptom = UnknownSymptom };

		var response = await SummitClient
			.DynamicServices
			.GetDynamicServiceResultAsync<GetIncidentIdsBySymptomRequest, List<GetIncidentIdsBySymptomResponseData>>(
				"DWS_IM_GetIncidentIDBySymptom", request, CancellationToken.None);

		response.Should().NotBeNull();
		response!.Should().HaveCount(0);
	}

	[Fact]
	public async Task GetIncidentBySymptom_RequestIsEmptyString_ReturnsNull()
	{
		var request = string.Empty;

		var response = await SummitClient
			.DynamicServices
			.GetDynamicServiceResultAsync<string, List<GetIncidentIdsBySymptomResponseData>>(
				"DWS_IM_GetIncidentIDBySymptom", request, CancellationToken.None);

		response.Should().BeNull();
	}

	[Fact]
	public async Task UnknownDynamicService_RequestWithSymptom_ReturnsNull()
	{
		var request = new GetIncidentIdsBySymptomRequest { Symptom = KnownSymptom };

		var response = await SummitClient
			.DynamicServices
			.GetDynamicServiceResultAsync<GetIncidentIdsBySymptomRequest, List<GetIncidentIdsBySymptomResponseData>>(
				"ABCDEFG", request, CancellationToken.None);

		response.Should().BeNull();
	}
}
