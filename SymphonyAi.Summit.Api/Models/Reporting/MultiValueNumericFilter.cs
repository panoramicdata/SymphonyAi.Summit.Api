using SymphonyAi.Summit.Api.Models.Reporting.Helpers;
using System.Text;

namespace SymphonyAi.Summit.Api.Models.Reporting;

public class MultiValueNumericFilter<T>(string columnName, MultiValueFilterOperators filterOperator, List<T> values) : IFilter where T : struct
{
	public string ColumnName { get; set; } = columnName;

	public MultiValueFilterOperators Operator { get; set; } = filterOperator;

	public List<T> Values { get; set; } = values;

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

			separatorRequired = true;
			_ = builder.Append(value);
		}

		_ = builder.Append(suffix);
		return builder.ToString();
	}
}