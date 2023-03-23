using SymphonyAi.Summit.Api.Models.Reporting.Helpers;

namespace SymphonyAi.Summit.Api.Reporting;

public class NullFilter : IFilter
{
	public NullFilter(string columnName)
	{
		ColumnName = columnName;
	}

	public string ColumnName { get; set; } = string.Empty;

	public string GetFilterExpression()
	{
		var columnName = SqlColumnNameFactory.BuildDelimitedColumnName(ColumnName);

		return $"{columnName} IS NULL";
	}
}