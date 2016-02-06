// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

using System;
using System.Threading.Tasks;

public class Async
{
	public async Task AwaitWithStack(Task<int> task)
	{
		Console.WriteLine("A", 1, await task);
	}
}
