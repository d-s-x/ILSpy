// #exclude v2 : compilation error
// #ignore v4r o- : not yet implemented

using System;
using System.Threading.Tasks;

public class Async
{
	public async Task<bool> SimpleBoolTaskMethod()
	{
		Console.WriteLine("Before");
		await Task.Delay(TimeSpan.FromSeconds(1.0));
		Console.WriteLine("After");
		return true;
	}

	public async void AwaitInLoopCondition()
	{
		while (await this.SimpleBoolTaskMethod()) 
		{
			Console.WriteLine("Body");
		}
	}
}
