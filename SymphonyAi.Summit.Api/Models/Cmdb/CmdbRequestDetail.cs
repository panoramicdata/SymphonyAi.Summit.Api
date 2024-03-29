﻿using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbRequestDetail
{
	[JsonPropertyName("InstanceName")]
	public string InstanceName { get; set; } = string.Empty;

	[JsonPropertyName("Active")]
	public bool? IsActive { get; set; }

	[JsonPropertyName("CIStatus")]
	public string? CiStatus { get; set; }

	[JsonPropertyName("CIID")]
	public int? Id { get; set; }
}
