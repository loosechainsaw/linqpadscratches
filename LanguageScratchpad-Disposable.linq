<Query Kind="Program" />

void Main()
{
	Func<int> f = () => Enumerable.Range(1,1000000).Count();
	f.WithTiming()().Dump();
}

public static class Evaluate
{
	private class Timer : IDisposable
	{

		public Timer()
		{
			start_ = DateTime.Now;
		}
		
		public void Dispose()
		{
			var duration = DateTime.Now - start_;
			Debug.WriteLine($"{duration.Milliseconds} Milliseconds");
		}
		
		private DateTime start_;
	}
	
	public static Func<T> WithTiming<T>(this Func<T> f)
	{
		return () =>
		{
			using (var timer = new Timer())
			{
				return f();
			}
		};
	}
}