<Query Kind="Program" />

void Main()
{
	1.To(5).Dump();
}

public static class RangeExtensions
{
	public static RangeEnumerable To(this int from, int to) => new RangeEnumerable(from,to);
}

public class RangeEnumerable : IEnumerable<int>
{
	public RangeEnumerable(int from, int to)
	{
		this.from = from;
		this.to = to;
	}
	
	public IEnumerator<int> GetEnumerator() => new RangeEnumerator(from,to);
	
	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
	
	private int from;
	private int to;
}

public class RangeEnumerator : IEnumerator<int>
{
	public RangeEnumerator(int from, int to)
	{
		this.from = from - 1;
		this.to = to;
	}

	public bool MoveNext() => from++ != to;

	public void Dispose() {}

	public void Reset() {}
	
	object IEnumerator.Current => this.Current;
	public int Current => from;
	
	private int from;
	private int to;
}
