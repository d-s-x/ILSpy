using System;

public static class Generics
{
	public static void MethodWithStructConstraint<T>() where T : struct
	{
	}
}
