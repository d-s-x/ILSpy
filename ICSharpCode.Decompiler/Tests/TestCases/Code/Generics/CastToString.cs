using System;

public static class Generics
{
	public static string CastToString<T>(T input)
	{
		return (string)((object)input);
	}
}
