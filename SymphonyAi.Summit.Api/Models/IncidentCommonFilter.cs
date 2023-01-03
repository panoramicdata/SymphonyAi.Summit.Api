﻿using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models;

public class IncidentCommonFilter
{
	[JsonPropertyName("Executive")]
	public int? Executive { get; set; }

	[JsonPropertyName("WorkgroupName")]
	public string WorkgroupName { get; set; } = string.Empty;

	[JsonPropertyName("CurrentPageIndex")]
	public int CurrentPageIndex { get; set; } = 1;

	[JsonPropertyName("PageSize")]
	public int PageSize { get; set; } = 100;

	[JsonPropertyName("OrgID")]
	public string OrgID { get; set; } = "1";

	[JsonPropertyName("Instance")]
	public string Instance { get; set; } = string.Empty;

	[JsonPropertyName("Status")]
	public string Status { get; set; } = "New,In-Progress";

	[JsonPropertyName("strUpdatedFromDate")]
	public string UpdatedFromDate { get; set; } = DateTimeOffset.UtcNow.AddDays(-1).ToString("yyyy-MM-dd");

	[JsonPropertyName("strUpdatedToDate")]
	public string UpdatedToDate { get; set; } = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd");

	[JsonPropertyName("IsWebServiceRequest")]
	public bool IsWebServiceRequest { get; } = true;

	[JsonPropertyName("CategoryName")]
	public string? CategoryName { get; set; }

	[JsonPropertyName("Categories")]
	public string? Categories { get; set; }
}
