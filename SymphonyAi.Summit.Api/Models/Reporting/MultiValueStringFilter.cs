using SymphonyAi.Summit.Api.Models.Reporting.Helpers;

namespace SymphonyAi.Summit.Api.Models.Reporting;

public class MultiValueStringFilter(string columnName, MultiValueFilterOperators filterOperator, List<string> values) : IFilter
{
	public string ColumnName { get; set; } = columnName;

	public MultiValueFilterOperators Operator { get; set; } = filterOperator;

	public List<string> Values { get; set; } = values;

	public string GetFilterExpression()
		=> SqlMultiValueExpressionFactory.Build(ColumnName, Operator, Values.Select(SqlStringValueFactory.BuildDelimitedEscapedValue));
}
