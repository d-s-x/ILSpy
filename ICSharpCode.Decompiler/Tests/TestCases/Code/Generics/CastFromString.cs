using System;

public static class Generics
{
	public static T CastFromString<T>(string input)
	{
		return (T)((object)input);
	}
}
