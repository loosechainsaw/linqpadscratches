<Query Kind="Program" />

void Main()
{
	var array = new Array<Derived>(10);

	foreach (var index in Enumerable.Range(0, 10))
	{
		array[index] = new Derived();
	}
	
	IIterable<Base> iterable = array;
	
	iterable.Dump();
	
}

public class Base {
};

public class Derived : Base { }

public interface IIterable<out T>
{
	IIterator<T> GetIterator();
}

public interface IIterator<out T>
{
	bool MoveNext();
	T Current { get;}
}

public class Array<T> : IIterable<T>
{

	public Array(int size)
	{
		this.elements_ = new T[size];
	}
	
	public IIterator<T> GetIterator() => new ArrayIterator<T>(this);

	public T this[int index]
	{
		get { return elements_[index]; }
		set { elements_[index] = value; }
	}
	
	public int Size => elements_.Length;
	
	private T[] elements_;
}

public class ArrayIterator<T> : IIterator<T>
{
	public ArrayIterator(Array<T> array)
	{
		elements_ = array;
		position_ = -1;
	}
	
	public bool MoveNext() => ++position_ != elements_.Size;
	
	public T Current => elements_[position_];
	
	private int position_;
	private Array<T> elements_;
}