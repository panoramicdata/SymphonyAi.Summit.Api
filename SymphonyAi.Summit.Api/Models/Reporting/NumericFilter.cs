using SymphonyAi.Summit.Api.Models.Reporting.Helpers;

namespace SymphonyAi.Summit.Api.Models.Reporting;

public class NumericFilter<T>(string columnName, NumericFilterOperators filterOperator, T value) : IFilter where T : struct
{
	public string ColumnName { get; set; } = columnName;

	public NumericFilterOperators Operator { get; set; } = filterOperator;

	public T Value { get; set; } = value;

	public string GetFilterExpression()
	{
		var columnName = SqlColumnNameFactory.BuildDelimitedColumnName(ColumnName);

		(var operatorPrefix, var operatorSuffix) = Operator switch
		{
			NumericFilterOperators.Equals => (" = ", ""),
			NumericFilterOperators.NotEquals => (" != ", ""),
			_ => throw new ArgumentException("Requested operator is not supported!")
		};

		return $"{columnName}{operatorPrefix}{Value}{operatorSuffix}";
	}
}