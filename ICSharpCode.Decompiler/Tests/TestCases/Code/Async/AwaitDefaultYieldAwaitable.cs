// #exclude v2 : compilation error
// #ignore v4r o- : not yet implemented

using System;
using System.Runtime.CompilerServices;

public class Async
{
	public async void AwaitDefaultYieldAwaitable()
	{
		await default(YieldAwaitable);
	}
}
