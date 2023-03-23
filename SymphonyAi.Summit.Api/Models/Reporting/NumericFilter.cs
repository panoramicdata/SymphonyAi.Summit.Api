namespace SymphonyAi.Summit.Api.Reporting;

public class NumericFilter<T> : IFilter where T : struct
{
	public NumericFilter(string columnName, FilterOperators filterOperator, T value)
	{
		ColumnName = columnName;
		Operator = filterOperator;
		Value = value;
	}

	public string ColumnName { get; set; } = string.Empty;

	public FilterOperators Operator { get; set; } = FilterOperators.Equals;

	public T Value { get; set; } = default;

	public string GetFilterExpression()
	{
		var columnName = ColumnName.Trim();
		if (!columnName.StartsWith('['))
		{
			columnName = "[" + columnName;
		}

		if (!columnName.EndsWith(']'))
		{
			columnName += "]";
		}

		var operatorPrefix = Operator switch
		{
			FilterOperators.Equals => " = ",
			FilterOperators.NotEquals => " != ",
			_ => throw new ArgumentException("Requested operator is not supported!")
		};

		var operatorSuffix = Operator switch
		{
			FilterOperators.Equals => "",
			FilterOperators.NotEquals => "",
			_ => throw new ArgumentException("Requested operator is not supported!")
		};

		return $"{columnName}{operatorPrefix}{Value}{operatorSuffix}";
	}
}