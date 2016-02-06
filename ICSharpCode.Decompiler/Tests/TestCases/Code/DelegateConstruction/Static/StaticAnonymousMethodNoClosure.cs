// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

using System;

public static class DelegateConstruction
{
	public static Action StaticAnonymousMethodNoClosure()
	{
		return delegate
		{
			Console.WriteLine();
		};
	}
}
