using FluentAssertions;
using SymphonyAi.Summit.Api.Models.Reporting;

namespace SymphonyAi.Summit.Api.Test;

public class StructuredDataQueryTests
{
	#region Table

	[Fact]
	public void Constructor_TableDataSource_GeneratesValidTableName()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter> { new NumericFilter<int>("Id", NumericFilterOperators.Equals, 1) },
			SortOrder = SortOrders.Descending
		});

		query.Table.Should().Be("Table1");
	}

	#endregion

	#region Columns

	[Fact]
	public void Constructor_OneColumn_GeneratesValidColumnExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1" },
			Filters = new List<IFilter> { new NumericFilter<int>("Id", NumericFilterOperators.Equals, 1) },
			SortOrder = SortOrders.Descending
		});

		query.Columns.Should().Be("[Column1]");
	}

	[Fact]
	public void Constructor_OneDelimitedColumn_GeneratesValidColumnExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "[Column1]" },
			Filters = new List<IFilter> { new NumericFilter<int>("Id", NumericFilterOperators.Equals, 1) },
			SortOrder = SortOrders.Descending
		});

		query.Columns.Should().Be("[Column1]");
	}

	[Fact]
	public void Constructor_TwoColumns_GeneratesValidColumnExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter> { new NumericFilter<int>("Id", NumericFilterOperators.Equals, 1) },
			SortOrder = SortOrders.Descending
		});

		query.Columns.Should().Be("[Column1],[Column2]");
	}

	[Fact]
	public void Constructor_TwoDelimitedColumns_GeneratesValidColumnExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "[Column1]", "[Column2]" },
			Filters = new List<IFilter> { new NumericFilter<int>("Id", NumericFilterOperators.Equals, 1) },
			SortOrder = SortOrders.Descending
		});

		query.Columns.Should().Be("[Column1],[Column2]");
	}

	[Fact]
	public void Constructor_ThreeColumns_GeneratesValidColumnExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2", "Column3" },
			Filters = new List<IFilter> { new NumericFilter<int>("Id", NumericFilterOperators.Equals, 1) },
			SortOrder = SortOrders.Descending
		});

		query.Columns.Should().Be("[Column1],[Column2],[Column3]");
	}

	#endregion

	#region Filters

	[Fact]
	public void Constructor_SingleNullFilter_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter> { new NullFilter("Id") },
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[Id] IS NULL");
	}

	[Fact]
	public void Constructor_TwoNullFilters_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter>
			{
				new NullFilter("Id"),
				new NullFilter("Name")
			},
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[Id] IS NULL AND [Name] IS NULL");
	}

	[Fact]
	public void Constructor_SingleNotNullFilter_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter> { new NotNullFilter("Id") },
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[Id] IS NOT NULL");
	}

	[Fact]
	public void Constructor_TwoNotNullFilters_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter>
			{
				new NotNullFilter("Id"),
				new NotNullFilter("Name")
			},
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[Id] IS NOT NULL AND [Name] IS NOT NULL");
	}

	[Fact]
	public void Constructor_SingleNumericEqualsFilter_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter> { new NumericFilter<int>("Id", NumericFilterOperators.Equals, 7) },
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[Id] = 7");
	}

	[Fact]
	public void Constructor_SingleNumericNotEqualsFilter_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter> { new NumericFilter<int>("Id", NumericFilterOperators.NotEquals, 7) },
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[Id] != 7");
	}

	[Fact]
	public void Constructor_TwoNumericEqualsFilters_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter>
			{
				new NumericFilter<int>("Id", NumericFilterOperators.Equals, 2),
				new NumericFilter<int>("DataTypeId", NumericFilterOperators.Equals, 3)
			},
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[Id] = 2 AND [DataTypeId] = 3");
	}

	[Fact]
	public void Constructor_SingleStringEqualsFilter_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter> { new StringFilter("Name", StringFilterOperators.Equals, "Fred") },
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[Name] = 'Fred'");
	}

	[Fact]
	public void Constructor_SingleStringNotEqualsFilter_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter> { new StringFilter("Name", StringFilterOperators.NotEquals, "Fred") },
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[Name] != 'Fred'");
	}

	[Fact]
	public void Constructor_TwoStringEqualsFilters_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter>
			{
				new StringFilter("FirstName", StringFilterOperators.Equals, "Fred"),
				new StringFilter("LastName", StringFilterOperators.Equals, "Smith"),
			},
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[FirstName] = 'Fred' AND [LastName] = 'Smith'");
	}

	[Fact]
	public void Constructor_OneMultiValueInStringFilter_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter>
			{
				new MultiValueStringFilter("LastName", MultiValueFilterOperators.In, new() { "Smith", "Jones" }),
			},
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[LastName] IN('Smith','Jones')");
	}

	[Fact]
	public void Constructor_OneMultiValueNotInStringFilter_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter>
			{
				new MultiValueStringFilter("LastName", MultiValueFilterOperators.NotIn, new() { "Smith", "Jones" }),
			},
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("[LastName] NOT IN('Smith','Jones')");
	}

	[Fact]
	public void Constructor_AnyOfTwoStringFilters_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter>
			{
				new AnyOfFilter(
					new StringFilter("FirstName", StringFilterOperators.Equals, "Fred"),
					new StringFilter("LastName", StringFilterOperators.Equals, "Smith")
				)
			},
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("([FirstName] = 'Fred' OR [LastName] = 'Smith')");
	}

	[Fact]
	public void Constructor_AnyOfOneNumericFilterAndOneStringFilter_GeneratesValidFilterExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter>
			{
				new AnyOfFilter(
					new NumericFilter<int>("Id", NumericFilterOperators.Equals, 2),
					new StringFilter("LastName", StringFilterOperators.Equals, "Smith")
				)
			},
			SortOrder = SortOrders.Descending
		});

		query.Filters.Should().Be("([Id] = 2 OR [LastName] = 'Smith')");
	}

	#endregion

	#region Sort Order

	[Fact]
	public void Constructor_AscendingSortOrder_GeneratesValidSortOrderExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter> { new NumericFilter<int>("Id", NumericFilterOperators.Equals, 1) },
			SortOrder = SortOrders.Ascending
		});

		query.SortOrder.Should().Be("ASC");
	}

	[Fact]
	public void Constructor_DescendingSortOrder_GeneratesValidSortOrderExpression()
	{
		var query = new StructuredDataQuery(new()
		{
			DataSource = "Table1",
			Columns = new List<string> { "Column1", "Column2" },
			Filters = new List<IFilter> { new NumericFilter<int>("Id", NumericFilterOperators.Equals, 1) },
			SortOrder = SortOrders.Descending
		});

		query.SortOrder.Should().Be("DESC");
	}

	#endregion
}
