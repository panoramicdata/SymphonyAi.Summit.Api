using SymphonyAi.Summit.Api.Models.Reporting.Helpers;

namespace SymphonyAi.Summit.Api.Models.Reporting;

public class NotNullFilter(string columnName) : IFilter
{
	public string ColumnName { get; set; } = columnName;

	public string GetFilterExpression()
	{
		var delimitedColumnName = SqlColumnNameFactory.BuildDelimitedColumnName(ColumnName);

		return $"{delimitedColumnName} IS NOT NULL";
	}
}