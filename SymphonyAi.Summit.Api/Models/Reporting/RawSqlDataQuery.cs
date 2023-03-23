namespace SymphonyAi.Summit.Api.Reporting;

public class RawSqlDataQuery : AdvancedDataQuery
{
	private readonly string _sql;

	public RawSqlDataQuery(string sql)
	{
		_sql = sql;
	}

	internal override DataQuery BuildDataQuery()
		=> new()
		{
			RawSql = _sql,
			SortOrder = string.Empty
		};
}
