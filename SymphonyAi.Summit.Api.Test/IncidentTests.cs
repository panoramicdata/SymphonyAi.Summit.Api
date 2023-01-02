using FluentAssertions;
using SymphonyAi.Summit.Api.Models;
using Xunit.Abstractions;

namespace SymphonyAi.Summit.Api.Test;

public class IncidentTests : TestBase
{
	public IncidentTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
	}

	[Fact]
	public async Task GetIncidentList_GoodRequest_Succeeds()
	{
		var request = new GetIncidentListRequest();

		var response = await SummitClient
			.Incidents
			.GetIncidentListAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
	}
}