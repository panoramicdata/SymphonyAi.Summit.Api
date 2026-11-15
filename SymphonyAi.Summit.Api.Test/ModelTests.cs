using AwesomeAssertions;
using SymphonyAi.Summit.Api.Models;
using SymphonyAi.Summit.Api.Models.Cmdb;
using System.Text.Json;

namespace SymphonyAi.Summit.Api.Test;

public class ModelTests
{
	[Fact]
	public void RelationshipInner_Deserializes_InheritedDeviceProperties()
	{
		const string json = """{"ID":7,"Serial_No":"SN1","IPAddress":"host-a","Device_HostName":"h","MAC_Address":"m"}""";

		var inner = JsonSerializer.Deserialize<CmdbRelationshipQueryResponseModelInner>(json)!;

		inner.Id.Should().Be(7);
		inner.SerialNumber.Should().Be("SN1");
		inner.IpAddress.Should().Be("host-a");
		inner.DeviceHostName.Should().Be("h");
		inner.MacAddress.Should().Be("m");
	}

	[Fact]
	public void RelationshipDetails_Serializes_InheritedDeviceProperties()
	{
		var details = new CmdbRelationshipDetails { SerialNumber = "SN2", IpAddress = "host-b", DeviceHostName = "h2" };

		var json = JsonSerializer.Serialize(details);

		json.Should().Contain("\"Serial_No\":\"SN2\"").And.Contain("\"IPAddress\":\"host-b\"").And.Contain("\"Device_Host_Name\":\"h2\"");
	}

	[Fact]
	public void ProxyDetails_Defaults_AreApiKeyJsonOrgOne()
	{
		var proxy = new ProxyDetails();

		proxy.AuthType.Should().Be("APIKEY");
		proxy.ReturnType.Should().Be("JSON");
		proxy.OrgId.Should().Be(1);
		proxy.ApiKey.Should().BeEmpty();
	}

	[Fact]
	public void IncidentCommonFilter_Defaults_StartAtFirstPageOfHundred()
	{
		var filter = new IncidentCommonFilter();

		filter.CurrentPageIndex.Should().Be(0);
		filter.PageSize.Should().Be(100);
		filter.Status.Should().Be("New,In-Progress");
		filter.IsWebServiceRequest.Should().BeTrue();
	}
}
