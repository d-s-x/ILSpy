// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

using System;

public static class DelegateConstruction
{
	public static Action<int> NameConflict3(int i)
	{
		return delegate(int j)
		{
			for (int k = 0; k < j; k++)
			{
				Console.WriteLine(k);
			}
		};
	}
}
