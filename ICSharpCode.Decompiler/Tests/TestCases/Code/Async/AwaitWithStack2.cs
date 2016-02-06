// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

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

	public async Task AwaitWithStack2(Task<int> task)
	{
		if (await this.SimpleBoolTaskMethod()) 
		{
			Console.WriteLine("A", 1, await task);
		} 
		else 
		{
			int num = 1;
			Console.WriteLine("A", 1, num);
		}
	}
}
