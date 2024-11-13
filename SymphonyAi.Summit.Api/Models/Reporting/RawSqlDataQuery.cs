namespace SymphonyAi.Summit.Api.Models.Reporting;

public class RawSqlDataQuery : DataQuery
{
	public RawSqlDataQuery(string sql)
	{
		RawSql = sql;
		SortOrder = string.Empty;
	}
}
