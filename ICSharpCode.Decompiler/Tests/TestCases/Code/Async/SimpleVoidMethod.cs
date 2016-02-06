// #exclude v2 : compilation error
// #ignore v4r o- : not yet implemented

using System;
using System.Threading.Tasks;

public class Async
{
	public async void SimpleVoidMethod()
	{
		Console.WriteLine("Before");
		await Task.Delay(TimeSpan.FromSeconds(1.0));
		Console.WriteLine("After");
	}
}
