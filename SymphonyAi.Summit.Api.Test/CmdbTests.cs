﻿using AwesomeAssertions;
using Microsoft.Extensions.Logging;
using SymphonyAi.Summit.Api.Models.Cmdb;
using System.Globalization;

namespace SymphonyAi.Summit.Api.Test;

[Trait("Category", "Integration")]
public class CmdbTests(ITestOutputHelper testOutputHelper) : TestBase(testOutputHelper)
{
	private CmdbCreateDetail BuildCiDetails(string classification, string remarks) => new()
	{
		InstanceName = Instance,
		DeviceHostName = Guid.NewGuid().ToString()[..8],
		SerialNumber = Guid.NewGuid().ToString(),
		WorkgroupName = WorkgroupName,
		OwnerName = OwnerName,
		ManagedByName = WorkgroupName,
		Classification = classification,
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
		AnnualMaintenanceContract = "Contract",
		Version = "1.0",
		Description = "Description",
		Remarks = remarks,
		IsTestPlanMandatory = false,
		PurchaseOrderNumber = "1234"
	};

	private async Task CreateCiAndAssertAsync(CmdbCreateDetail details)
	{
		var request = new CmdbCreateCiRequest();
		request.CommonParameters.CmdbDetails = details;

		var response = await SummitClient
			.Cmdb
			.CreateCiAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
		response.Errors.Should().BeNullOrEmpty();
		response.OutputId.Should().BePositive();
		response.Output.Should().NotBeNullOrEmpty();
	}

	private static void SetRelation(CmdbRelationship relation, int sourceCiId, string targetCiId)
	{
		relation.SourceType = "CI";
		relation.TargetType = "CI";
		relation.SourceKey = "CIID";
		relation.TargetKey = "CIID";
		relation.SourceValue = sourceCiId.ToString(CultureInfo.InvariantCulture);
		relation.TargetValue = targetCiId;
		relation.Relationship = "Peer";
	}

	private async Task<CmdbDeleteRelationshipResponse> DeletePeerRelationshipAsync(int sourceCiId, string targetCiId)
	{
		var deleteRequest = new CmdbDeleteRelationshipRequest();
		SetRelation(deleteRequest.CommonParameters.Relation, sourceCiId, targetCiId);

		var deleteResponse = await SummitClient
			.Cmdb
			.DeleteRelationshipAsync(deleteRequest, CancellationToken.None);

		deleteResponse.Should().NotBeNull();
		deleteResponse.Errors.Should().BeEmpty();

		return deleteResponse;
	}

	[Fact]
	public async Task CreateServerCi_GoodRequest_Succeeds()
	{
		var details = BuildCiDetails("Server", "Remarks");
		details.ServerIpAddress = "1.2.3.4";
		details.ServerCpu = "8 Core Processor";
		details.ServerHardDiskDrive = "80 GB";
		details.ServerRam = "8 GB RAM";
		details.ServerNic = "2";
		details.ServerNetwork = "LAN";
		details.ServerRaidLevel = "1";
		details.ServerRaidCard = "2";
		details.ServerBackupState = true;
		details.ServerBackupDetails = "Back up on secondary";
		details.ServerOperatingSystem = "Windows 2016 Standard";
		details.ServerServicePack = "SP 1";
		details.ServerInstalledApplications = "Windows";
		details.ServerPatches = "Windows";

		await CreateCiAndAssertAsync(details);
	}

	[Fact]
	public async Task CreateAndRetireNetworkCi_GoodRequest_Succeeds()
	{
		var details = BuildCiDetails("Network Device", "1213");
		details.NetworkIpAddress = "20.10.1.2";
		details.NetworkSubnetMask = "255.255.255.0";
		details.NetworkGateway = "20.10.8.154";
		details.NetworkSlotCount = "2";
		details.NetworkSlotNumbers = "2";
		details.NetworkPorts = "20";
		details.NetworkCardType = "NIC";
		details.NetworkVlan = "10";
		details.NetworkFlashMemory = "2";
		details.NetworkDramMemory = "2";
		details.NetworkIosSoftware = "Crisco";
		details.NetworkAccessList = "ACL";
		details.NetworkRoutes = "20";
		details.NetworkAEndDescription = "NETWROK A DESCRIPTION";
		details.NetworkAEndIpAddress = "Network A IP Address";
		details.NetworkBEndDescription = "NETWROK B DESCRIPTION";
		details.NetworkBEndIpAddress = "Network B IP Address";
		details.NetworkCircuitId = "CircuitID";

		await CreateCiAndAssertAsync(details);
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
			int.TryParse(x.ConfigurationItemId, out var _).Should().Be(true);
		});
	}

	[Fact]
	public async Task GetCi_GoodRequest_Succeeds()
	{
		var request = new CmdbCiRequest();
		request.CommonParameters.CmdbDetails.InstanceName = Instance;
		request.CommonParameters.CmdbDetails.Id = 37;

		var response = await SummitClient
			.Cmdb
			.GetCiAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
		response.OutputObject.Should().NotBeNull();
		response.OutputObject.Root.Should().NotBeNull();
	}

	[Fact]
	public async Task LinkAndRefetchAndDelink_GoodRequest_Succeeds()
	{
		const int sourceCiId = 628;
		const int targetCiId = 629;
		var targetCiIdString = targetCiId.ToString(CultureInfo.InvariantCulture);

		var queryRequest = new CmdbRelationshipQueryRequest();
		queryRequest.CommonParameters.CmdbDetails.InstanceName = Instance;
		queryRequest.CommonParameters.CmdbDetails.ConfigurationId = sourceCiId.ToString(CultureInfo.InvariantCulture);
		var queryResponse = await SummitClient
			.Cmdb
			.GetRelationshipsAsync(queryRequest, CancellationToken.None);
		queryResponse.Should().NotBeNull();
		queryResponse.Errors.Should().BeEmpty();

		foreach (var relationship in queryResponse.OutputObject?.CiRelations ?? [])
		{
			await DeletePeerRelationshipAsync(sourceCiId, relationship.Id.ToString(CultureInfo.InvariantCulture));
		}

		var createRequest = new CmdbCreateRelationshipRequest();
		SetRelation(createRequest.CommonParameters.Relation, sourceCiId, targetCiIdString);

		var createResponse = await SummitClient
			.Cmdb
			.CreateRelationshipAsync(createRequest, CancellationToken.None);

		createResponse.Should().NotBeNull();
		createResponse.Errors.Should().BeEmpty();

		try
		{
			queryResponse = await SummitClient
				.Cmdb
				.GetRelationshipsAsync(queryRequest, CancellationToken.None);
			queryResponse.Should().NotBeNull();
			queryResponse.Errors.Should().BeEmpty();
			queryResponse.OutputObject.Should().NotBeNull();
		}
		catch (Exception)
		{
			Logger.LogError("Re-fetch failed.");
			throw;
		}
		finally
		{
			(await DeletePeerRelationshipAsync(sourceCiId, targetCiIdString)).OutputObject.Should().BeNull();
		}
	}
}
