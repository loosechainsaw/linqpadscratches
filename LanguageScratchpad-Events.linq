<Query Kind="Program" />

void Main()
{
	
	Broadcaster<int> broadcaster = new Broadcaster<int>(44);
	broadcaster.Handler += (value) => value.Dump();

	foreach (var value in Enumerable.Range(1, 10))
	{
		broadcaster.Value = value;
	}
	
}

public class ValueChangedArgs<T> : System.EventArgs
{
	public T Value { get; set;}
}

public delegate void ValueChangedHandler<T>(ValueChangedArgs<T> value);

public class Broadcaster<T>
{

	public Broadcaster(T value)
	{
		Value = value;
	}

	public T Value
	{
		get { return value_; }
		set
		{
			bool same = Equals(value_,value);
			value_ = value;

			if (!same)
				Handler?.Invoke(new ValueChangedArgs<T> { Value = value_});
		}
	}

	public event ValueChangedHandler<T> Handler;
	private T value_;
}