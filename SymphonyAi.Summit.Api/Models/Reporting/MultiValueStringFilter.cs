using SymphonyAi.Summit.Api.Models.Reporting.Helpers;
using System.Text;

namespace SymphonyAi.Summit.Api.Models.Reporting;

public class MultiValueStringFilter(string columnName, MultiValueFilterOperators filterOperator, List<string> values) : IFilter
{
	public string ColumnName { get; set; } = columnName;

	public MultiValueFilterOperators Operator { get; set; } = filterOperator;

	public List<string> Values { get; set; } = values;

	public string GetFilterExpression()
	{
		var columnName = SqlColumnNameFactory.BuildDelimitedColumnName(ColumnName);

		var (prefix, suffix, itemSeparator) = Operator switch
		{
			MultiValueFilterOperators.In => (" IN(", ")", ","),
			MultiValueFilterOperators.NotIn => (" NOT IN(", ")", ","),
			_ => throw new ArgumentException("Requested operator is not supported!")
		};

		var builder = new StringBuilder(Values.Count * 25);
		_ = builder.Append(columnName + prefix);

		var separatorRequired = false;
		foreach (var value in Values)
		{
			if (separatorRequired)
			{
				_ = builder.Append(itemSeparator);
			}

			var delimitedEscapedValue = SqlStringValueFactory.BuildDelimitedEscapedValue(value);

			_ = builder.Append(delimitedEscapedValue);
			separatorRequired = true;
		}

		_ = builder.Append(suffix);
		return builder.ToString();
	}
}