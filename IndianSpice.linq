<Query Kind="Program" />

void Main()
{
	Func<int,int,int> add = (x,y) => x + y;
	add.Curry()(3)(5).Dump();
}

public static class FunctionalExtensions
{
	public static Func<T, Func<U, V>> Curry<T, U, V>(this Func<T, U, V> f) => x => y => f(x,y);
}
