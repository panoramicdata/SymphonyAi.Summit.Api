using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbRelationship
{

	/// <summary>
	/// Type of Source
	/// Permitted values:
	/// - CI
	/// - Service
	/// </summary>
	[JsonPropertyName("SourceType")]
	public string SourceType { get; set; } = string.Empty;

	/// <summary>
	/// Type of Target
	/// - CI
	/// - Service
	/// </summary>
	[JsonPropertyName("TargetType")]
	public string TargetType { get; set; } = string.Empty;

	/// <summary>
	/// Name of the source.  May be:
	/// CI-CI OR CI-Service
	/// - CIID
	/// - HostName
	/// - SerialNo
	/// - IP Address
	///
	/// Service-Service
	/// - Service ID
	/// - ServiceName
	/// </summary>
	[JsonPropertyName("SourceKey")]
	public string SourceKey { get; set; } = string.Empty;

	/// <summary>
	/// Name of the source.  May be:
	/// CI-CI OR Service-CI
	/// - CIID
	/// - HostName
	/// - SerialNo
	/// - IP Address
	///
	/// Service-Service
	/// - Service ID
	/// - ServiceName
	/// </summary>
	[JsonPropertyName("TargetKey")]
	public string TargetKey { get; set; } = string.Empty;

	/// <summary>
	/// Value of the Source
	/// If the SourceKey parameter value is CIID, must be an integer or else string.
	/// </summary>
	[JsonPropertyName("SourceValue")]
	public string SourceValue { get; set; } = string.Empty;

	/// <summary>
	/// Relationship between the Source and Target.
	/// </summary>
	[JsonPropertyName("Relationship")]
	public string Relationship { get; set; } = string.Empty;

	/// <summary>
	/// Value of the Target
	/// If the TargetKey parameter value is CIID, must be an integer or else string.
	/// </summary>
	[JsonPropertyName("TargetValues")]
	public string TargetValue { get; set; } = string.Empty;
}
