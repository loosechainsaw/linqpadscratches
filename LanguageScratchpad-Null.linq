<Query Kind="Program" />

void Main()
{
	int? value = 5;
	var result = value ?? 6;
	result.Dump();
	
	var container = new Container();
	var message = container?.Contained?.Message ?? "Hello Elvis";
	message.Dump();
}


public class Container
{
	public Inner Contained { get; set; }

	public class Inner {

		public string Message { get; set;}
	}
}
