using SymphonyAi.Summit.Api.Models.Reporting.Helpers;

namespace SymphonyAi.Summit.Api.Models.Reporting;

public class StringFilter(string columnName, StringFilterOperators filterOperator, string value) : IFilter
{
	public string ColumnName { get; set; } = columnName;

	public StringFilterOperators Operator { get; set; } = filterOperator;

	public string Value { get; set; } = value;

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