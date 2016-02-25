using System;

public static class Generics
{
	public static bool IsString<T>(T input)
	{
		return input is string;
	}
}
