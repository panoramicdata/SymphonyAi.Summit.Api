namespace SymphonyAi.Summit.Api.Reporting;

public class RawSqlDataQuery : DataQuery
{
	public RawSqlDataQuery(string sql)
	{
		RawSql = sql;
		SortOrder = string.Empty;
	}
}
