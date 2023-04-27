using FluentAssertions;
using SymphonyAi.Summit.Api.Models.Cmdb;
using System.Globalization;
using Xunit.Abstractions;

namespace SymphonyAi.Summit.Api.Test;

public class CmdbTests : TestBase
{
	public CmdbTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
	}

	[Fact]
	public async Task CreateServerCi_GoodRequest_Succeeds()
	{
		var request = new CmdbCreateCiRequest();
		request.CommonParameters.CmdbDetails = new()
		{
			InstanceName = Instance,
			DeviceHostName = Guid.NewGuid().ToString()[..8],
			SerialNumber = Guid.NewGuid().ToString(),
			WorkgroupName = WorkgroupName,
			OwnerName = OwnerName,
			ManagedByName = WorkgroupName,
			Classification = "Server",
			Status = "Production",
			LifecycleStatus = "Design",
			CriticalityName = "Critical",
			CustomerName = CustomerName,
			VendorName = "IBM",
			LocationName = "",
			Make = "Cisco",
			MacAddress = "3E:45:DT:G6",
			IpAddress = "",
			ModelNumber = "VMware",
			Rack = "Rack1",
			Warranty = "2023-12-31",
			AnnualMaintainsContract = "Contract",
			Version = "1.0",
			Description = "Description",
			Remarks = "Remarks",
			IsTestPlanMandatory = false,
			PurchaseOrderNumber = "1234",
			ServerIpAddress = "1.2.3.4",
			ServerCpu = "8 Core Processor",
			ServerHardDiskDrive = "80 GB",
			ServerRam = "8 GB RAM",
			ServerNic = "2",
			ServerNetwork = "LAN",
			ServerRaidLevel = "1",
			ServerRaidCard = "2",
			ServerBackupState = true,
			ServerBackupDetails = "Back up on secondary",
			ServerOperatingSystem = "Windows 2016 Standard",
			ServerServicePack = "SP 1",
			ServerInstalledApplications = "Windows",
			ServerPatches = "Windows"
		};

		var response = await SummitClient
			.Cmdb
			.CreateCiAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
		response.Errors.Should().BeNullOrEmpty();
		response.OutputId.Should().BePositive();
		response.Output.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task CreateNetworkCi_GoodRequest_Succeeds()
	{
		var request = new CmdbCreateCiRequest();
		request.CommonParameters.CmdbDetails = new()
		{
			InstanceName = Instance,
			DeviceHostName = Guid.NewGuid().ToString()[..8],
			SerialNumber = Guid.NewGuid().ToString(),
			WorkgroupName = WorkgroupName,
			OwnerName = OwnerName,
			ManagedByName = WorkgroupName,
			Classification = "Network Device",
			Status = "Production",
			LifecycleStatus = "Design",
			CriticalityName = "Critical",
			CustomerName = CustomerName,
			VendorName = "IBM",
			LocationName = "",
			Make = "Cisco",
			MacAddress = "3E:45:DT:G6",
			IpAddress = "",
			ModelNumber = "VMware",
			Rack = "Rack1",
			Warranty = "2023-12-31",
			AnnualMaintainsContract = "Contract",
			Version = "1.0",
			Description = "Description",
			Remarks = "1213",
			IsTestPlanMandatory = false,
			PurchaseOrderNumber = "1234",
			NetworkIpAddress = "20.10.1.2",
			NetworkSubnetMask = "255.255.255.0",
			NetworkGateway = "20.10.8.154",
			NetworkSlotCount = "2",
			NetworkSlotNumbers = "2",
			NetworkPorts = "20",
			NetworkCardType = "NIC",
			NetworkVlan = "10",
			NetworkFlashMemory = "2",
			NetworkDramMemory = "2",
			NetworkIosSoftware = "Crisco",
			NetworkAccessList = "ACL",
			NetworkRoutes = "20",
			NetworkAEndDescription = "NETWROK A DESCRIPTION",
			NetworkAEndIpAddress = "Network A IP Address",
			NetworkBEndDescription = "NETWROK B DESCRIPTION",
			NetworkBEndIpAddress = "Network B IP Address",
			NetworkCircuitId = "CircuitID",
		};

		var response = await SummitClient
			.Cmdb
			.CreateCiAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
		response.Errors.Should().BeNullOrEmpty();
		response.OutputId.Should().BePositive();
		response.Output.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task GetCis_GoodRequest_Succeeds()
	{
		var request = new CmdbQueryRequest();
		request.CommonParameters.CmdbDetails.InstanceName = Instance;

		var response = await SummitClient
			.Cmdb
			.GetCisAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
		response.OutputObject.Should().NotBeNull();
		response.OutputObject.Details.Should().NotBeNull();
		response.OutputObject.Details.Count.Should().Be(1);
		response.OutputObject.Details[0].Should().NotBeNull();
		response.OutputObject.Details[0].Details.Should().AllSatisfy(x =>
		{
			x.ConfigurationItemId.Should().NotBeEmpty();
			int.TryParse(x.ConfigurationItemId, out int _).Should().Be(true);
		});
	}

	[Fact]
	public async Task GetCi_GoodRequest_Succeeds()
	{
		var request = new CmdbCiRequest();
		request.CommonParameters.CmdbDetails.InstanceName = Instance;
		request.CommonParameters.CmdbDetails.Id = 1;

		var response = await SummitClient
			.Cmdb
			.GetCiAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
		response.OutputObject.Should().NotBeNull();
		response.OutputObject.Root.Should().NotBeNull();
	}

	//[Fact]
	//public async Task GetCis2_GoodRequest_Succeeds()
	//{
	//	var request = new CmdbQuery2Request();
	//	request.CommonParameters.CmdbDetails.InstanceName = Instance;

	//	var response = await SummitClient
	//		.Cmdb
	//		.GetCis2Async(request, CancellationToken.None);

	//	response.Should().NotBeNull();

	//	response.OutputObject.Should().NotBeNull();
	//}

	[Fact]
	public async Task LinkAndDelink_GoodRequest_Succeeds()
	{
		var sourceCiId = 630;
		var targetCiId = 631;

		var createRequest = new CmdbCreateRelationshipRequest();
		createRequest.Relation.SourceType = "CI";
		createRequest.Relation.TargetType = "CI";
		createRequest.Relation.SourceKey = "CIID";
		createRequest.Relation.TargetKey = "CIID";
		createRequest.Relation.SourceValue = sourceCiId.ToString(CultureInfo.InvariantCulture);
		createRequest.Relation.TargetValue = targetCiId.ToString(CultureInfo.InvariantCulture);
		createRequest.Relation.Relationship = "Peer";

		var createResponse = await SummitClient
			.Cmdb
			.CreateRelationshipAsync(createRequest, CancellationToken.None);

		createResponse.Should().NotBeNull();
		createResponse.Errors.Should().BeEmpty();
		createResponse.OutputObject.Should().NotBeNull();

		var deleteRequest = new CmdbDeleteRelationshipRequest();
		deleteRequest.Relation.SourceType = "CI";
		deleteRequest.Relation.TargetType = "CI";
		deleteRequest.Relation.SourceKey = "CIID";
		deleteRequest.Relation.TargetKey = "CIID";
		deleteRequest.Relation.SourceValue = sourceCiId.ToString(CultureInfo.InvariantCulture);
		deleteRequest.Relation.TargetValue = targetCiId.ToString(CultureInfo.InvariantCulture);
		deleteRequest.Relation.Relationship = "Peer";

		var deleteResponse = await SummitClient
			.Cmdb
			.DeleteRelationshipAsync(deleteRequest, CancellationToken.None);

		deleteResponse.Should().NotBeNull();
		deleteResponse.Errors.Should().BeEmpty();
		deleteResponse.OutputObject.Should().NotBeNull();
	}
}