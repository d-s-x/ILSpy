// #exclude v2 : compilation error

using System;
using System.Collections.Generic;

public static class DelegateConstruction
{
	public static List<Action<int>> AnonymousMethodStoreWithinLoop()
	{
		List<Action<int>> list = new List<Action<int>>();
		for (int i = 0; i < 10; i++)
		{
			int counter;
			list.Add(delegate(int x)
			{
				counter = x;
			});
		}
		return list;
	}
}
