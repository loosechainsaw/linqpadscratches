<Query Kind="Program" />

void Main()
{
	var a1 = new int[] { 1, 2, 3, 4, 5, 6 };
	var a2 = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };;
	
	a1.Dump();
	a2.Dump();
	
	a1.Foldl(0, (x,y) => x + y).Dump();
	
}

public static class RectangularArrayExtensions
{
	public static U FoldlAllDimensions<T, U>(this T[,] array, U zero, Func<U, T, U> f)
	{
		for (int i = 0; i < array.GetLength(0); ++i)
		{

		}
	}
}

public static class IterableExtensions
{
	public static U Foldl<T, U>(this IEnumerable<T> elements, U zero, Func<U, T, U> f)
	{
		foreach (var item in elements)
		{
			zero = f(zero, item);
		}
		
		return zero;
	}
}


