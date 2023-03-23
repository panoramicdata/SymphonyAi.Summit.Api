using SymphonyAi.Summit.Api.Models.Reporting.Helpers;

namespace SymphonyAi.Summit.Api.Reporting;

public class StringFilter : IFilter
{
	public StringFilter(string columnName, StringFilterOperators filterOperator, string value)
	{
		ColumnName = columnName;
		Operator = filterOperator;
		Value = value;
	}

	public string ColumnName { get; set; } = string.Empty;

	public StringFilterOperators Operator { get; set; } = StringFilterOperators.Equals;

	public string Value { get; set; } = string.Empty;

	public string GetFilterExpression()
	{
		var columnName = SqlColumnNameFactory.BuildDelimitedColumnName(ColumnName);

		(var operatorPrefix, var operatorSuffix) = Operator switch
		{
			StringFilterOperators.Equals => (" = '", "'"),
			StringFilterOperators.NotEquals => (" != '", "'"),
			StringFilterOperators.StartsWith => (" LIKE '", "%'"),
			_ => throw new ArgumentException("Requested operator is not supported!")
		};

		var escapedValue = SqlStringValueFactory.BuildEscapedValue(Value);

		return $"{columnName}{operatorPrefix}{escapedValue}{operatorSuffix}";
	}
}