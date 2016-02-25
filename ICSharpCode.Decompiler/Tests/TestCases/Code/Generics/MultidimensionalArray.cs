using System;

public static class Generics
{
	private static void MultidimensionalArray<T>(T[,] array)
	{
		array[0, 0] = array[0, 1];
	}
}
