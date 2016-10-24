<Query Kind="Program" />

void Main()
{
	Vector<int> v = new Vector<int>();
	foreach (var element in Enumerable.Range(1, 19))
	{
		v.Pushback(element);
	}

	v.Size.Dump();
	v.Capacity.Dump();
	
	v[3].Dump();

	foreach (var element in v)
	{
		element.Dump();
	}

}


public class Vector<T> : IEnumerable<T>
{
	public Vector()
	{
		elements_ = null;
		size_ = 0;
		capacity_ = 0;
	}

	public Vector(int capacity)
	{
		Resize(capacity);
	}

	private void Resize(int capacity)
	{
		if (capacity == 0)
		{
			capacity_ = 1;
			size_ = 0;
			elements_ = new T[Capacity];
			return;
		}

		$"Resizing from {Capacity} to {Capacity * 2}".Dump();

		capacity *= 2;
		var elements = new T[capacity];
		Array.Copy(elements_, elements, capacity_);

		elements_ = elements;
		capacity_ = capacity;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return elements_.GetEnumerator();
	}

	public IEnumerator<T> GetEnumerator()
	{

		int counter = 0;

		foreach (var item in elements_)
		{
			if (counter++ == Size)
				yield break;
			yield return item;
		}
	}

	public void Pushback(T element)
	{
		if (IsFull)
			Resize(Capacity);

		elements_[size_++] = element;
	}

	public void Clear()
	{
		if (IsEmpty)
			return;

		elements_ = null;
		size_ = 0;
		capacity_ = 0;
	}

	public T this[int index]
	{
		get { return elements_[index]; }
		set { elements_[index] = value; }
	}

	public int Capacity => capacity_;

	public int Size => size_;

	public bool IsFull => Capacity == Size;

	public bool IsEmpty => Size == 0;

	private T[] elements_;
	private int capacity_;
	private int size_;
}
