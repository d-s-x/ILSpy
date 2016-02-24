// #ignore v4r o+ : not yet implemented (exception variable name is not preserved)

using System;

public class ExceptionHandling
{
	public void TwoCatchBlocksWithSameVariable()
	{
		try
		{
			Console.WriteLine("Try1");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		try
		{
			Console.WriteLine("Try2");
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
	}
}
