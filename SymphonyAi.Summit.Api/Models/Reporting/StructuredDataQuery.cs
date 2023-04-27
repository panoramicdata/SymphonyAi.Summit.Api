namespace SymphonyAi.Summit.Api.Reporting;

public class StructuredDataQuery : DataQuery
{
	public StructuredDataQuery(StructuredDataQueryParameters queryParameters)
	{
		Table = queryParameters.DataSource;
		Columns = queryParameters.BuildColumnsExpression();
		Filters = queryParameters.BuildFiltersExpression();
		PageNumber = queryParameters.PageNumber;
		PageSize = queryParameters.PageSize.ToString();
		SortColumn = queryParameters.SortColumn;
		SortOrder = queryParameters.BuildSortOrderExpression();
		RawSql = string.Empty;
	}
}
