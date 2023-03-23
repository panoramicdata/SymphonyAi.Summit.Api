using SymphonyAi.Summit.Api.Models.Reporting.Helpers;

namespace SymphonyAi.Summit.Api.Reporting;

public class NumericFilter<T> : IFilter where T : struct
{
	public NumericFilter(string columnName, NumericFilterOperators filterOperator, T value)
	{
		ColumnName = columnName;
		Operator = filterOperator;
		Value = value;
	}

	public string ColumnName { get; set; } = string.Empty;

	public NumericFilterOperators Operator { get; set; } = NumericFilterOperators.Equals;

	public T Value { get; set; } = default;

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