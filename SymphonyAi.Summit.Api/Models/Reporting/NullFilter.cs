using SymphonyAi.Summit.Api.Models.Reporting.Helpers;

namespace SymphonyAi.Summit.Api.Models.Reporting;

public class NullFilter(string columnName) : IFilter
{
	public string ColumnName { get; set; } = columnName;

	public string GetFilterExpression()
	{
		var columnName = SqlColumnNameFactory.BuildDelimitedColumnName(ColumnName);

		return $"{columnName} IS NULL";
	}
}