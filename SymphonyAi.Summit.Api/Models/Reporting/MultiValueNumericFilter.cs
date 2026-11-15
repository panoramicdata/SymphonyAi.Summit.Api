using SymphonyAi.Summit.Api.Models.Reporting.Helpers;

namespace SymphonyAi.Summit.Api.Models.Reporting;

public class MultiValueNumericFilter<T>(string columnName, MultiValueFilterOperators filterOperator, List<T> values) : IFilter where T : struct
{
	public string ColumnName { get; set; } = columnName;

	public MultiValueFilterOperators Operator { get; set; } = filterOperator;

	public List<T> Values { get; set; } = values;

	public string GetFilterExpression()
		=> SqlMultiValueExpressionFactory.Build(ColumnName, Operator, Values.Select(value => value.ToString()!));
}
