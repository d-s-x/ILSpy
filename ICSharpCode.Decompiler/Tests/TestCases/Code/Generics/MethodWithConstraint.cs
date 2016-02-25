using System;

public static class Generics
{
	public static void MethodWithConstraint<T, S>() where T : class, S where S : ICloneable, new()
	{
	}
}
