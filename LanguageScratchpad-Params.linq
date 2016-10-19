<Query Kind="Program" />

void Main()
{
	Functions.Foldl((x,y) => x + y, 0, 1, 2, 3).Dump();
}

public static class Functions
{
	public static U Foldl<T, U>(Func<U, T, U> f, U zero, params T[] values)
	{
		foreach (var item in values)
			zero = f(zero, item);
		return zero;
	}

}