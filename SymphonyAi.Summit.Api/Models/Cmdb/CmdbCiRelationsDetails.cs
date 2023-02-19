using System.Text.Json.Serialization;

namespace SymphonyAi.Summit.Api.Models.Cmdb;

public class CmdbCiRelationsDetails
{
	[JsonPropertyName("BackupConfigItems")]
	public object BackupConfigItems { get; set; }

	[JsonPropertyName("ChildConfigItems")]
	public object ChildConfigItems { get; set; }

	[JsonPropertyName("ParentConfigItems")]
	public object ParentConfigItems { get; set; }

	[JsonPropertyName("PeerConfigItems")]
	public object PeerConfigItems { get; set; }
}
