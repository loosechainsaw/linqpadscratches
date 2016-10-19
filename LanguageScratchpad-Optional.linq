<Query Kind="Program" />

void Main()
{
	var value = GetValueOrDefault(55);
	var empty = GetValueOrDefault<string>();
	
	value.Dump();
	empty.Dump();
}

T GetValueOrDefault<T>(T value = default(T)) => value;
