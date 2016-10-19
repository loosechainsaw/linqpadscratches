<Query Kind="Program" />

void Main()
{
	var values = Enumerable.Range(1,10);
	values.Total().Dump();
	values.Avg().Dump();
}

public static class EnumerableExtensions
{
	public static U FoldLeft<T, U>(this IEnumerable<T> elements, U zero, Func<U, T, U> f)
	{
		foreach (var element in elements)
		{
			zero = f(zero, element);
		}
		return zero;
	}
	
	public static int Total<T>(this IEnumerable<T> elements) => elements.FoldLeft(0, (current, _) => current + 1);
	
	public static int Summation(this IEnumerable<int> elements) => elements.FoldLeft(0, (current, v) => current + v);

	public static double Avg(this IEnumerable<int> elements)
	{
		var t = elements.FoldLeft(Tuple.Create(0, 0), (current, v) => Tuple.Create(current.Item1 + 1, current.Item2 + v));
		return t.Item2 / t.Item1;
	}
}

