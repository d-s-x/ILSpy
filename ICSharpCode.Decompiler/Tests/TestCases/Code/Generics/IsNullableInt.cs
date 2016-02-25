using System;

public static class Generics
{
	public static bool IsNullableInt<T>(T input)
	{
		return input is int?;
	}
}
