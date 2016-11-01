<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

void Main()
{
	Func<int, ITrampoline<int>> f = null;

	f = n =>
	{
		if (n == 1) 
			return new TrampolineResult<int> { Result = 1};
		
		int accum = 1;
		
		var continuation = new TrampolineContinuation<int>();
		continuation.Continuation = () => accum * (n - 1);
    };
}

public interface ITrampoline<T>
{
	bool IsComplete { get; }
	T Result { get;}
}

public class TrampolineResult<T> : ITrampoline<T>
{
	public bool IsComplete
	{
		get { return true; }
	}

	public T Result { get; set;}
}

public class TrampolineContinuation<T> : ITrampoline<T>
{
	public bool IsComplete
	{
		get { return false; }
	}

	public T Result
	{
		get
		{
			throw new InvalidOperationException();
		}
	}

	public Func<ITrampoline<T>> Continuation { get; set;}
}

public static class Trampoline
{
	public static T Process<T>(ITrampoline<T> trampoline)
	{

		while (!trampoline.IsComplete)
		{
			trampoline = ((TrampolineContinuation<T>) trampoline).Continuation();
		}
		
		return trampoline.Result;
	}
}