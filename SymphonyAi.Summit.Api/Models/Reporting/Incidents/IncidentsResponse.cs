using System.Runtime.Serialization;

namespace SymphonyAi.Summit.Api.Models.Reporting.Incidents;

[DataContract]
public class IncidentsResponse : ReportingResponse<Incident>
{
}
