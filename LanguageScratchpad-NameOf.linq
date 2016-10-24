<Query Kind="Program" />

void Main()
{
	PrintArgument(44);
	PrintArgument("Hello world");
}

void PrintArgument<T>(T value)
{
	$"{nameof(value)} contains: {value}".Dump();
}
