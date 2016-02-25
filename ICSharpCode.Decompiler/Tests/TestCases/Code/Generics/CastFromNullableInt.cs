using System;

public static class Generics
{
	public static T CastFromNullableInt<T>(int? input)
	{
		return (T)((object)input);
	}
}
