﻿using AwesomeAssertions;
using SymphonyAi.Summit.Api.Models;

namespace SymphonyAi.Summit.Api.Test;

[Trait("Category", "Integration")]
public class IncidentTests(ITestOutputHelper testOutputHelper) : TestBase(testOutputHelper)
{
	private GetIncidentDetailsAndChangeHistoryRequest BuildDetailsRequest()
	{
		var request = new GetIncidentDetailsAndChangeHistoryRequest();
		request.CommonParameters.TicketNumber = TicketNumber;
		request.CommonParameters.RequestType = "RemoteCall";
		return request;
	}

	private async Task<CreateOrUpdateIncidentRequest> BuildCreateRequestAsync()
	{
		var request = await LoadObjectFromJsonFile<CreateOrUpdateIncidentRequest>("CreateIncidentRequest", TestContext.Current.CancellationToken);
		var ticket = request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.Ticket;
		ticket.AssignedWorkGroupName = WorkgroupName;
		ticket.CallerEmailId = CallerEmailId;
		ticket.Symptom = Guid.NewGuid().ToString();

		request.ServiceName.Should().Be("IM_LogOrUpdateIncident");
		request.CommonParameters.RequestType.Should().Be("RemoteCall");
		return request;
	}

	private async Task CreateIncidentAndAssertAsync()
	{
		var request = await BuildCreateRequestAsync();

		var response = await SummitClient.Incidents.CreateOrUpdateIncidentAsync(request, CancellationToken.None);
		response.Should().NotBeNull();
		response.Errors.Should().BeEmpty();
		response.TicketNumber.Should().BeGreaterThan(0);
	}

	[Fact]
	public async Task GetIncidentList_GoodRequest_Succeeds()
	{
		var request = new GetIncidentListRequest();
		request.CommonParameters.IncidentCommonFilter = new()
		{
			Instance = Instance
		};

		var response = await SummitClient
			.Incidents
			.GetIncidentListAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
	}

	[Fact]
	public async Task GetIncidentListDetails_GoodRequest_Succeeds()
	{
		var request = new GetIncidentListDetailsRequest();
		request.CommonParameters.IncidentCommonFilter!.Instance = Instance;
		request.CommonParameters.IncidentCommonFilter!.CurrentPageIndex = 2;

		var response = await SummitClient
			.Incidents
			.GetIncidentListDetailsAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
		response.OutputObject.MyTickets.Should().NotBeNull();
	}

	[Fact]
	public async Task GetIncidentListDetails_SeveralPageRequests_Succeeds()
	{
		var request = new GetIncidentListDetailsRequest();
		request.CommonParameters.IncidentCommonFilter!.Instance = Instance;
		request.CommonParameters.IncidentCommonFilter!.Status = "Open,Reopened,New,Assigned,In-Progress,Pending";
		request.CommonParameters.IncidentCommonFilter!.UpdatedFromDate = "2023-02-01";

		var pageIndex = 0;
		var incidents = new List<Ticket>();
		GetIncidentListResponse response;
		do
		{
			request.CommonParameters.IncidentCommonFilter!.CurrentPageIndex = pageIndex;
			response = await SummitClient
				.Incidents
				.GetIncidentListDetailsAsync(request, CancellationToken.None);

			incidents.AddRange(response.OutputObject.MyTickets);

			pageIndex++;
		} while (response.OutputObject.MyTickets.Count > 0 && pageIndex < 3);

		var ids = string.Concat(incidents.Select(i => i.IncidentDetail[0].IncidentId + ","));

		ids.Should().NotBeNull();
	}

	[Fact]
	public async Task GetIncidentDetailsAndChangeHistory_GoodRequest_Succeeds()
	{
		var response = await SummitClient
			.Incidents
			.GetIncidentDetailsAndChangeHistoryAsync(BuildDetailsRequest(), CancellationToken.None);

		response.Should().NotBeNull();
	}

	[Fact]
	public async Task GetIncidentDetailsAndChangeHistory_SingleIncident_ReturnsOneIncident()
	{
		var response = await SummitClient
			.Incidents
			.GetIncidentDetailsAndChangeHistoryAsync(BuildDetailsRequest(), CancellationToken.None);

		response.OutputObject.IncidentDetails.TicketDetails.Count.Should().Be(1);
	}

	[Fact]
	public async Task CreateIncident_GoodRequest_Succeeds()
		=> await CreateIncidentAndAssertAsync();
}
