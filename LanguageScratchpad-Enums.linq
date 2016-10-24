<Query Kind="Program" />

void Main()
{
	var colour = PrimaryColour.Green;

	if (colour == PrimaryColour.Green)
	{
		$"You like {colour}".Dump();
	}
	
	var value = (byte)colour;
	value.Dump();
	
	colour = (PrimaryColour)value;
	colour.Dump();
}

enum PrimaryColour : System.Byte
{
	Red = 1,
	Green = 2,
	Blue = 3
}
