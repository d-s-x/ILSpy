// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

using System;
using System.Collections.Generic;

public static class DelegateConstruction
{
	public static void NameConflict()
	{
		// i is captured variable,
		// j is parameter in anonymous method
		// k is local in anonymous method,
		// l is local in main method
		// Ensure that the decompiler doesn't introduce name conflicts
		List<Action<int>> list = new List<Action<int>>();
		for (int l = 0; l < 10; l++)
		{
			int i;
			for (i = 0; i < 10; i++)
			{
				list.Add(delegate(int j)
				{
					for (int k = 0; k < i; k += j)
					{
						Console.WriteLine();
					}
				});
			}
		}
	}
}
