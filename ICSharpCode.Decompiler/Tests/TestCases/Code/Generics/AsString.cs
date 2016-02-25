using System;

public static class Generics
{
	public static string AsString<T>(T input)
	{
		return input as string;
	}
}
