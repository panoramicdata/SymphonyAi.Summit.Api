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

		var response = await SummitClient
			.Incidents
			.GetIncidentListDetailsAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
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
	public async Task CreateIncident_GoodRequest_Succeeds()
	{
		// Load CreateOrUpdateIncidentRequest from file CreateIncidentRequest.json
		var request = await LoadObjectFromJsonFile<CreateOrUpdateIncidentRequest>("CreateIncidentRequest", default);
		request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.Ticket.AssignedWorkGroupName = WorkgroupName;
		request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.Ticket.CallerEmailId = CallerEmailId;

		//request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.Ticket.Symptom = Guid.NewGuid().ToString();

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

		var customField = new
		{
			GroupName = "Integration",
			Name = "External Issue ID",
			Value = "13579"
		};
		request.CommonParameters.IncidentParamsJson.IncidentContainerJsonObj.CustomFields.Add(customField);

		request.ServiceName.Should().Be("IM_LogOrUpdateIncident");
		request.CommonParameters.RequestType.Should().Be("RemoteCall");

		var response = await SummitClient.Incidents.CreateOrUpdateIncidentAsync(request, CancellationToken.None);
		response.Should().NotBeNull();
		response.Errors.Should().BeEmpty();
		response.TicketNumber.Should().BeGreaterThan(0);
	}
}