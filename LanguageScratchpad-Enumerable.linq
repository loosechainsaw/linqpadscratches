<Query Kind="Program" />

void Main()
{
	
	var generator = new CountGenerator(1, 10);
	foreach (var element in generator )
	{
		element.Dump();
	}

	foreach (var element in generator)
	{
		element.Dump();
	}

}

class CountGenerator : IEnumerable<int>
{
	public CountGenerator(int from, int to)
	{
		this.from = from;
		this.to = to;
	}

	public IEnumerator<int> GetEnumerator()
	{
		return new CountGeneratorEnumerator(from, to);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new CountGeneratorEnumerator(from, to);
	}

	private class CountGeneratorEnumerator : IEnumerator<int>
	{
		public CountGeneratorEnumerator(int start, int end)
		{
			start_ = start - 1;
			end_ = end;
		}

		public bool MoveNext()
		{
			return ++start_ <= end_;
		}

		public void Dispose() {}

		public void Reset() {}
		
		object IEnumerator.Current => start_;
		
		public int Current => start_;
		
		private int start_;
		private int end_;
	}
	
	private int from;
	private int to;

}