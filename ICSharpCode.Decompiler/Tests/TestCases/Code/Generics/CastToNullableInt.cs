using System;

public static class Generics
{
	public static int? CastToNullableInt<T>(T input)
	{
		return (int?)((object)input);
	}
}
