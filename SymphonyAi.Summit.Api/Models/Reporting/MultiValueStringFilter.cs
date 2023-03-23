using SymphonyAi.Summit.Api.Models.Reporting.Helpers;
using System.Text;

namespace SymphonyAi.Summit.Api.Reporting;

public class MultiValueStringFilter : IFilter
{
	public MultiValueStringFilter(string columnName, MultiValueFilterOperators filterOperator, List<string> values)
	{
		ColumnName = columnName;
		Operator = filterOperator;
		Values = values;
	}

	public string ColumnName { get; set; } = string.Empty;

	public MultiValueFilterOperators Operator { get; set; } = MultiValueFilterOperators.In;

	public List<string> Values { get; set; } = new();

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