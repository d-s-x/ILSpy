using System;

public static class Generics
{
	public static bool IsInt<T>(T input)
	{
		return input is int;
	}
}
