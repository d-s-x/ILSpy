// #ignore v4r o+ : not yet implemented (exception variable name is not preserved)

using System;

public class ExceptionHandling
{
	public void TryCatchMultipleHandlers()
	{
		try
		{
			Console.WriteLine("Try");
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine(ex.Message);
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.Message);
		}
		catch
		{
			Console.WriteLine("other");
		}
	}
}
