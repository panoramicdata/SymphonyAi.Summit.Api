namespace SymphonyAi.Summit.Api.Models.Reporting.Helpers;

internal static class SqlColumnNameFactory
{
	public static string BuildDelimitedColumnName(string columnName)
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
}
