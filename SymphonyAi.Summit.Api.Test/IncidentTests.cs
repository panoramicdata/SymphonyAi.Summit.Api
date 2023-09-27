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

		var results = response.OutputObject.MyTickets;
		var ids = string.Concat(results.Select(i => i.IncidentDetail[0].IncidentId + ","));

		response.Should().NotBeNull();
	}

	[Fact(Skip = "This is now a very slow test, so it has been replaced with GetIncidentListDetails_SeveralPageRequests_Succeeds")]
	public async Task GetIncidentListDetails_MultiplePageRequests_Succeeds()
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
		} while (response.OutputObject.MyTickets.Count > 0);

		var ids = string.Concat(incidents.Select(i => i.IncidentDetail[0].IncidentId + ","));

		ids.Should().NotBeNull();
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
		var request = new GetIncidentDetailsAndChangeHistoryRequest();
		request.CommonParameters.TicketNumber = TicketNumber;
		request.CommonParameters.RequestType = "RemoteCall";

		var response = await SummitClient
			.Incidents
			.GetIncidentDetailsAndChangeHistoryAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
	}

	[Fact]
	public async Task GetIncidentDetailsAndChangeHistory_SingleIncident_ReturnsOneIncident()
	{
		var request = new GetIncidentDetailsAndChangeHistoryRequest();
		request.CommonParameters.TicketNumber = TicketNumber;
		request.CommonParameters.RequestType = "RemoteCall";

		var response = await SummitClient
			.Incidents
			.GetIncidentDetailsAndChangeHistoryAsync(request, CancellationToken.None);

		response.OutputObject.IncidentDetails.TicketDetails.Count.Should().Be(1);
	}

	[Fact]
	public async Task CreateIncident_GoodRequest_Succeeds()
	{
		// Load CreateOrUpdateIncidentRequest from file CreateIncidentRequest.json
		var request = await LoadObjectFromJsonFile<CreateOrUpdateIncidentRequest>("CreateIncidentRequest", default);
		request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.Ticket.AssignedWorkGroupName = WorkgroupName;
		request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.Ticket.CallerEmailId = CallerEmailId;

		request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.Ticket.Symptom = Guid.NewGuid().ToString();

		request.ServiceName.Should().Be("IM_LogOrUpdateIncident");
		request.CommonParameters.RequestType.Should().Be("RemoteCall");

		var response = await SummitClient.Incidents.CreateOrUpdateIncidentAsync(request, CancellationToken.None);
		response.Should().NotBeNull();
		response.Errors.Should().BeEmpty();
		response.TicketNumber.Should().BeGreaterThan(0);
	}

	[Fact]
	public async Task CreateIncident_GoodRequestWithCustomField_Succeeds()
	{
		// Load CreateOrUpdateIncidentRequest from file CreateIncidentRequest.json
		var request = await LoadObjectFromJsonFile<CreateOrUpdateIncidentRequest>("CreateIncidentRequest", default);
		request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.Ticket.AssignedWorkGroupName = WorkgroupName;
		request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.Ticket.CallerEmailId = CallerEmailId;

		request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.Ticket.Symptom = Guid.NewGuid().ToString();

		//var customField = new
		//{
		//	GroupName = "Integration",
		//	Name = "External Issue ID",
		//	Value = "13579"
		//};
		//request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.CustomFields.Add(customField);

		request.ServiceName.Should().Be("IM_LogOrUpdateIncident");
		request.CommonParameters.RequestType.Should().Be("RemoteCall");

		var response = await SummitClient.Incidents.CreateOrUpdateIncidentAsync(request, CancellationToken.None);
		response.Should().NotBeNull();
		response.Errors.Should().BeEmpty();
		response.TicketNumber.Should().BeGreaterThan(0);
	}
}