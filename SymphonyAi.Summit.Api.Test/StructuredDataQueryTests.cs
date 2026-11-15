using AwesomeAssertions;
using SymphonyAi.Summit.Api.Models.Reporting;

namespace SymphonyAi.Summit.Api.Test;

public class StructuredDataQueryTests
{
	private static StructuredDataQuery Build(
		List<string>? columns = null,
		List<IFilter>? filters = null,
		SortOrders sortOrder = SortOrders.Descending)
		=> new(new()
		{
			DataSource = "Table1",
			Columns = columns ?? ["Column1", "Column2"],
			Filters = filters ?? [new NumericFilter<int>("Id", NumericFilterOperators.Equals, 1)],
			SortOrder = sortOrder
		});

	[Fact]
	public void Constructor_TableDataSource_GeneratesValidTableName()
		=> Build().Table.Should().Be("Table1");

	[Theory]
	[InlineData("Column1", "[Column1]")]
	[InlineData("[Column1]", "[Column1]")]
	[InlineData("Column1,Column2", "[Column1],[Column2]")]
	[InlineData("[Column1],[Column2]", "[Column1],[Column2]")]
	[InlineData("Column1,Column2,Column3", "[Column1],[Column2],[Column3]")]
	public void Constructor_Columns_GeneratesValidColumnExpression(string columns, string expected)
		=> Build(columns: [.. columns.Split(',')]).Columns.Should().Be(expected);

	public static IEnumerable<object[]> FilterCases()
	{
		yield return Case("[Id] IS NULL", new NullFilter("Id"));
		yield return Case("[Id] IS NULL AND [Name] IS NULL", new NullFilter("Id"), new NullFilter("Name"));
		yield return Case("[Id] IS NOT NULL", new NotNullFilter("Id"));
		yield return Case("[Id] IS NOT NULL AND [Name] IS NOT NULL", new NotNullFilter("Id"), new NotNullFilter("Name"));
		yield return Case("[Id] = 7", new NumericFilter<int>("Id", NumericFilterOperators.Equals, 7));
		yield return Case("[Id] != 7", new NumericFilter<int>("Id", NumericFilterOperators.NotEquals, 7));
		yield return Case(
			"[Id] = 2 AND [DataTypeId] = 3",
			new NumericFilter<int>("Id", NumericFilterOperators.Equals, 2),
			new NumericFilter<int>("DataTypeId", NumericFilterOperators.Equals, 3));
		yield return Case("[Name] = 'Fred'", new StringFilter("Name", StringFilterOperators.Equals, "Fred"));
		yield return Case("[Name] != 'Fred'", new StringFilter("Name", StringFilterOperators.NotEquals, "Fred"));
		yield return Case("[Name] LIKE 'Fr%'", new StringFilter("Name", StringFilterOperators.StartsWith, "Fr"));
		yield return Case(
			"[FirstName] = 'Fred' AND [LastName] = 'Smith'",
			new StringFilter("FirstName", StringFilterOperators.Equals, "Fred"),
			new StringFilter("LastName", StringFilterOperators.Equals, "Smith"));
		yield return Case("[LastName] IN('Smith','Jones')", new MultiValueStringFilter("LastName", MultiValueFilterOperators.In, ["Smith", "Jones"]));
		yield return Case("[LastName] NOT IN('Smith','Jones')", new MultiValueStringFilter("LastName", MultiValueFilterOperators.NotIn, ["Smith", "Jones"]));
		yield return Case("[Id] IN(1,2,3)", new MultiValueNumericFilter<int>("Id", MultiValueFilterOperators.In, [1, 2, 3]));
		yield return Case("[Id] NOT IN(4)", new MultiValueNumericFilter<int>("Id", MultiValueFilterOperators.NotIn, [4]));
		yield return Case(
			"([FirstName] = 'Fred' OR [LastName] = 'Smith')",
			new AnyOfFilter(
				new StringFilter("FirstName", StringFilterOperators.Equals, "Fred"),
				new StringFilter("LastName", StringFilterOperators.Equals, "Smith")));
		yield return Case(
			"([Id] = 2 OR [LastName] = 'Smith')",
			new AnyOfFilter(
				new NumericFilter<int>("Id", NumericFilterOperators.Equals, 2),
				new StringFilter("LastName", StringFilterOperators.Equals, "Smith")));
	}

	private static object[] Case(string expected, params IFilter[] filters) => [expected, filters];

	[Theory]
	[MemberData(nameof(FilterCases))]
	public void Constructor_Filters_GeneratesValidFilterExpression(string expected, IFilter[] filters)
		=> Build(filters: [.. filters]).Filters.Should().Be(expected);

	[Theory]
	[InlineData(SortOrders.Ascending, "ASC")]
	[InlineData(SortOrders.Descending, "DESC")]
	public void Constructor_SortOrder_GeneratesValidSortOrderExpression(SortOrders sortOrder, string expected)
		=> Build(sortOrder: sortOrder).SortOrder.Should().Be(expected);

	[Fact]
	public void Constructor_UnsupportedSortOrder_GeneratesNotSupportedMessage()
		=> Build(sortOrder: (SortOrders)99).SortOrder.Should().Be("Sort order is not supported!");

	[Theory]
	[InlineData("Id", "[Id]")]
	[InlineData("  Id  ", "[Id]")]
	[InlineData("[Id", "[Id]")]
	[InlineData("Id]", "[Id]")]
	public void Constructor_ColumnNameForms_AreDelimited(string name, string expected)
		=> new NullFilter(name).GetFilterExpression().Should().Be($"{expected} IS NULL");

	[Fact]
	public void NumericFilter_UnsupportedOperator_Throws()
		=> new NumericFilter<int>("Id", (NumericFilterOperators)99, 1)
			.Invoking(f => f.GetFilterExpression())
			.Should().Throw<ArgumentException>();

	[Fact]
	public void MultiValueFilter_UnsupportedOperator_Throws()
		=> new MultiValueStringFilter("Id", (MultiValueFilterOperators)99, ["a"])
			.Invoking(f => f.GetFilterExpression())
			.Should().Throw<ArgumentException>();

	[Fact]
	public void StringFilter_UnsupportedOperator_Throws()
		=> new StringFilter("Id", (StringFilterOperators)99, "a")
			.Invoking(f => f.GetFilterExpression())
			.Should().Throw<ArgumentException>();

	[Fact]
	public void Constructor_Defaults_CopyPagingValues()
	{
		var query = Build();
		query.PageNumber.Should().Be(1);
		query.PageSize.Should().Be("10000");
		query.RawSql.Should().BeEmpty();
	}
}
