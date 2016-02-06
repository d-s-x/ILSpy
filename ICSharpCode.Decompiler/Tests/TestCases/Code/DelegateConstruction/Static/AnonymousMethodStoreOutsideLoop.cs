// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

using System;
using System.Collections.Generic;

public static class DelegateConstruction
{
	public static List<Action<int>> AnonymousMethodStoreOutsideLoop()
	{
		List<Action<int>> list = new List<Action<int>>();
		int counter;
		for (int i = 0; i < 10; i++)
		{
			list.Add(delegate(int x)
			{
			    counter = x;
			});
		}
		return list;
	}
}
