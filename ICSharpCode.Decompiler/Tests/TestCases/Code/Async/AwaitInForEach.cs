// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Async
{
	public async Task<int> AwaitInForEach(IEnumerable<Task<int>> elements)
	{
		int num = 0;
		foreach (Task<int> current in elements)
		{
			num += await current;
		}
		return num;
	}
}
