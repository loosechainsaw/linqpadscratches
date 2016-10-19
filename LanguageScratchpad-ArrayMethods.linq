<Query Kind="Program" />

void Main()
{
	var array1 = new int[] { 1, 2, 3, 4 };
	var array2 = new int[array1.Length];
	
	Array.Copy(array1, array2, array1.Length);
	
	array2.Dump();

}

