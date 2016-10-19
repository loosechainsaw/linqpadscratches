<Query Kind="Program" />

void Main()
{
	3.Seconds().Dump();
	
}

public static class TimespanExtensions
{
	
	public static TimeSpan MilliSeconds(this int value) => TimeSpan.FromMilliseconds(value);
	
	public static TimeSpan Seconds(this int value) => TimeSpan.FromSeconds(value);
	
	public static TimeSpan Minutes(this int value) => TimeSpan.FromMinutes(value);
	
	public static TimeSpan Hours(this int value) => TimeSpan.FromHours(value);
	
	public static TimeSpan Days(this int value) => TimeSpan.FromDays(value);
	
}