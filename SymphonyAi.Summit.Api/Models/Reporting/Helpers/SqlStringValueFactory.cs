namespace SymphonyAi.Summit.Api.Models.Reporting.Helpers;

internal static class SqlStringValueFactory
{
	public static string BuildEscapedValue(string value)
	{
		value = value.Replace("'", "''");
		value = value.Replace("`", "``");
		// TODO: Add additional escaping and protection

		return value;
	}

	public static string BuildDelimitedEscapedValue(string value)
	{
		value = BuildEscapedValue(value);

		return "'" + value + "'";
	}
}
