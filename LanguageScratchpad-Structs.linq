<Query Kind="Program" />

void Main()
{
	Point origin = new Point();
	origin.Dump();
	
	Point other = new Point(3,4);
	other.Dump();
}

public struct Point
{

	public Point(int x, int y) 
	{
		X = x;
		Y = y;
	}

	public override string ToString() => $"{X}, {Y}";
	
	public int X { get; set; }
	public int Y { get; set; }
}
