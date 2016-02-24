using System;

public class ExceptionHandling
{
	public void MethodEndingWithEndFinally()
	{
		try
		{
			throw null;
		}
		finally
		{
			Console.WriteLine();
		}
	}
}
