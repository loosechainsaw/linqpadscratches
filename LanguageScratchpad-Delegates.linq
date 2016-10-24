<Query Kind="Program" />

void Main()
{
	Transformer t1 = new Transformer(Square);
	Transformer t2 = Square;
	
	t1(2).Dump();
	t2(2).Dump();
}

int Square(int value) => value * 2;
delegate int Transformer(int x);