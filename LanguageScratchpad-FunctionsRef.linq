<Query Kind="Program" />

void Main()
{
	int value = 1;
	value.Dump();
	
	NonIncrement(value);
	value.Dump();
	
	Increment(ref value);
	value.Dump();
}

void Increment(ref int value)
{
	value += 1;
}

void NonIncrement(int value)
{
	value += 1;
}
