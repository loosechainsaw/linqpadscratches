<Query Kind="Program" />

void Main()
{
	Transformer<int,double> t = new Transformer<int, double>(1, x => x * 1.2);
	t.Map().Dump();
}

public class Transformer<T, U>
{
	public Transformer(T value, Function f)
	{
		this.value = value;
		this.f = f;
	}
	
	public U Map() => f(value); 
	
	public delegate U Function(T element);
	
	private Function f;
	private T value;
}
