using System;

public class ExceptionHandling
{
	public void MethodEndingWithRethrow()
	{
		try
		{
			throw null;
		}
		catch
		{
			throw;
		}
	}
}
