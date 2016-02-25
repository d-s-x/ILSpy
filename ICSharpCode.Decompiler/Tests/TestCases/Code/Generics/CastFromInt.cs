using System;

public static class Generics
{
	public static T CastFromInt<T>(int input)
	{
		return (T)((object)input);
	}
}
