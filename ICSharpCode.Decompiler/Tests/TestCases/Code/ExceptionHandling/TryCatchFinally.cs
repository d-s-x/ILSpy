// #ignore v4r o+ : not yet implemented (exception variable name is not preserved)

using System;

public class ExceptionHandling
{
	public void TryCatchFinally()
	{
		try
		{
			Console.WriteLine("Try");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		finally
		{
			Console.WriteLine("Finally");
		}
	}
}
