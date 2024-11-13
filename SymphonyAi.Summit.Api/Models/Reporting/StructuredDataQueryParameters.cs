using System.Text;

namespace SymphonyAi.Summit.Api.Models.Reporting;

public class StructuredDataQueryParameters
{
	public string DataSource { get; set; } = string.Empty;

	public List<string> Columns { get; set; } = [];

	public List<IFilter> Filters { get; set; } = [];

	public int PageNumber { get; set; } = 1;

	public int PageSize { get; set; } = 10000;

	public string SortColumn { get; set; } = string.Empty;

	public SortOrders SortOrder { get; set; } = SortOrders.Ascending;

	internal string BuildFiltersExpression()
	{
		var builder = new StringBuilder(Filters.Count * 50);

		foreach (var filter in Filters)
		{
			if (builder.Length > 0)
			{
				_ = builder.Append(" AND ");
			}

			_ = builder.Append(filter.GetFilterExpression());
		}

		return builder.ToString();
	}

	internal string BuildColumnsExpression()
	{
		var builder = new StringBuilder(Columns.Count * 50);

		foreach (var columnName in Columns)
		{
			if (builder.Length > 0)
			{
				_ = builder.Append(',');
			}

			_ = builder.Append(DelimitColumnName(columnName));
		}

		return builder.ToString();
	}

	private static string DelimitColumnName(string columnName)
	{
		columnName = columnName.Trim();
		if (!columnName.StartsWith('['))
		{
			columnName = "[" + columnName;
		}

		if (!columnName.EndsWith(']'))
		{
			columnName += "]";
		}

		return columnName;
	}

	internal string BuildSortOrderExpression()
		=> SortOrder switch
		{
			SortOrders.Ascending => "ASC",
			SortOrders.Descending => "DESC",
			_ => "Sort order is not supported!"
		};
}
