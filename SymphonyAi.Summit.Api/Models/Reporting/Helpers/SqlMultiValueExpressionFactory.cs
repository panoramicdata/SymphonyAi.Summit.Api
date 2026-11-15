namespace SymphonyAi.Summit.Api.Models.Reporting.Helpers;

internal static class SqlMultiValueExpressionFactory
{
	public static string Build(string columnName, MultiValueFilterOperators filterOperator, IEnumerable<string> renderedValues)
	{
		var (prefix, suffix) = filterOperator switch
		{
			MultiValueFilterOperators.In => (" IN(", ")"),
			MultiValueFilterOperators.NotIn => (" NOT IN(", ")"),
			_ => throw new ArgumentException("Requested operator is not supported!")
		};

		return SqlColumnNameFactory.BuildDelimitedColumnName(columnName) + prefix + string.Join(",", renderedValues) + suffix;
	}
}
