namespace SymphonyAi.Summit.Api.Reporting;

public class StringFilter : IFilter
{
	public StringFilter(string columnName, FilterOperators filterOperator, string value)
	{
		ColumnName = columnName;
		Operator = filterOperator;
		Value = value;
	}

	public string ColumnName { get; set; } = string.Empty;

	public FilterOperators Operator { get; set; } = FilterOperators.Equals;

	public string Value { get; set; } = string.Empty;

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

		return $"{columnName}{operatorPrefix}'{Value}'{operatorSuffix}";
	}
}