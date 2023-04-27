using System.Text;

namespace SymphonyAi.Summit.Api.Reporting;

/// <summary>
/// Aggregating filter for use when other filters must be combined with an OR operation
/// </summary>
/// <remarks>
/// This filter will result in the return of rows that meet any one of the filters provided
/// </remarks>
public class AnyOfFilter : IFilter
{
	private readonly List<IFilter> _filters;

	public AnyOfFilter(IFilter filter1, IFilter filter2)
	{
		_filters = new List<IFilter>() { filter1, filter2 };
	}

	public AnyOfFilter(IFilter filter1, IFilter filter2, IFilter filter3)
	{
		_filters = new List<IFilter>() { filter1, filter2, filter3 };
	}

	public AnyOfFilter(IFilter filter1, IFilter filter2, IFilter filter3, IFilter filter4)
	{
		_filters = new List<IFilter>() { filter1, filter2, filter3, filter4 };
	}

	public AnyOfFilter(IFilter filter1, IFilter filter2, IFilter filter3, IFilter filter4, IFilter filter5)
	{
		_filters = new List<IFilter>() { filter1, filter2, filter3, filter4, filter5 };
	}

	public string GetFilterExpression()
	{
		var builder = new StringBuilder(_filters.Count * 100);

		_ = builder.Append('(');

		foreach (var filter in _filters)
		{
			if (builder.Length > 2)
			{
				_ = builder.Append(" OR ");
			}

			_ = builder.Append(filter.GetFilterExpression());
		}

		_ = builder.Append(')');
		return builder.ToString();
	}
}
