// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

using System;
using System.Collections.Generic;

public static class DelegateConstruction
{
	public static void NameConflict2(int j)
	{
		List<Action<int>> list = new List<Action<int>>();
		for (int k = 0; k < 10; k++)
		{
			list.Add(delegate(int i)
			{
				Console.WriteLine(i);
			});
		}
	}
}
