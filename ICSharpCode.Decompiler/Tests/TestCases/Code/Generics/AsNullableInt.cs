using System;

public static class Generics
{
	public static int? AsNullableInt<T>(T input)
	{
		return input as int?;
	}
}
