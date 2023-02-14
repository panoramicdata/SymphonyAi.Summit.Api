using FluentAssertions;
using SymphonyAi.Summit.Api.Models.Cmdb;
using Xunit.Abstractions;

namespace SymphonyAi.Summit.Api.Test;

public class CmdbTests : TestBase
{
	public CmdbTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
	}

	[Fact]
	public async Task CreateCi_GoodRequest_Succeeds()
	{
		var request = new CmdbCreateOrUpdateCiRequest();
		request.CommonParameters.CmdbDetails = new()
		{
			InstanceName = Instance,
			Hostname = Guid.NewGuid().ToString(),
			SerialNumber = Guid.NewGuid().ToString(),
			OwnerWorkgroupName = WorkgroupName,
			OwnerName = OwnerName,
			ManagedBy = WorkgroupName,
			Classification = "Server",
			Status = "Production",
			LifecycleStatus = "Design",
			CriticalityName = "Critical",
			VendorName = "IBM",
			LocationName = "",
			Make = "Cisco",
			MacAddress = "00:00:00:00:00:00",
			IpAddress = "",
			ModelNumber = "1234",
			Rack = "Rack 1",
			Warranty = "2023-12-31",
			AnnualMaintainsContract = "Contract",
			Version = "1.0",
			Description = "Description",
			Remarks = "Remarks",
			IsTestPlanMandatory = true,
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
			.CreateOrUpdateCiAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
		response.Errors.Should().BeNullOrEmpty();
		response.OutputObjects.Should().NotBeEmpty();
		response.OutputObjects[0].Should().NotBeNull();
		response.OutputObjects[0].ConfigurationId.Should().MatchRegex(@"^\d+$");
	}

	[Fact]
	public async Task GetCiList_GoodRequest_Succeeds()
	{
		var request = new CmdbQueryRequest();

		var response = await SummitClient
			.Cmdb
			.GetCisAsync(request, CancellationToken.None);

		response.Should().NotBeNull();
	}
}