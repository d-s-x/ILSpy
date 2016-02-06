// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

using System;
using System.IO;
using System.Threading.Tasks;

public class Async
{
	public async Task TaskMethodWithoutAwaitButWithExceptionHandling()
	{
		try 
		{
			using (new StringWriter())
			{
				Console.WriteLine("No Await");
			}
		} 
		catch (Exception) 
		{
			Console.WriteLine("Crash");
		}
	}
}
