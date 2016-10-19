<Query Kind="Program" />

void Main()
{
	 var s = new Some<int>(10);
	 s.SelectMany(x => new Some<int>(x + 2).SelectMany(y => new None<int>())).Dump();
}

public interface IMaybe<out T>
{
	IMaybe<U> Select<U>(Func<T,U> f);
	IMaybe<U> SelectMany<U>(Func<T, IMaybe<U>> f);
}

public class None<T> : IMaybe<T>
{
	public IMaybe<U> Select<U>(Func<T,U> f) => new None<U>();
	public IMaybe<U> SelectMany<U>(Func<T,IMaybe<U>> f) => new None<U>();
}

public class Some<T> : IMaybe<T>
{
	public Some(T value)
	{
		Value = value;
	}

	public IMaybe<U> Select<U>(Func<T, U> f) => new Some<U>(f(Value));
	public IMaybe<U> SelectMany<U>(Func<T, IMaybe<U>> f) => f(Value);

	public T Value { get;}
}
