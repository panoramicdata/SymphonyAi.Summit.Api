namespace SymphonyAi.Summit.Api.Models.Reporting.Incidents;

public class IncidentsDataPage(DataPage dataPage)
{
	private readonly DataPage _dataPage = dataPage;
	private readonly List<Incident> _incidents = new List<Incident>(dataPage.Results.Select(r => (Incident)r));

	public Pagination Pagination => _dataPage.Pagination;

	public IReadOnlyList<Incident> Incidents => _incidents;

	public Status Status => _dataPage.Status;
}
