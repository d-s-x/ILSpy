// #exclude v2 : compilation error
// #ignore v4r o- : not yet implemented

using System;
using System.Threading.Tasks;

public class Async
{
	public async void AwaitYield()
	{
		await Task.Yield();
	}
}
