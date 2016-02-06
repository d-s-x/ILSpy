// #exclude v2 : compilation error
// #ignore v4r o- : not yet implemented

using System;
using System.Threading.Tasks;

public class Async
{
	public async Task<int> NestedAwait(Task<Task<int>> task)
	{
		return await(await task);
	}
}
