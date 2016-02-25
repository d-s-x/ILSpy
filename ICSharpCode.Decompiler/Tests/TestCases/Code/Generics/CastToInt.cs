using System;

public static class Generics
{
	public static int CastToInt<T>(T input)
	{
		return (int)((object)input);
	}
}
