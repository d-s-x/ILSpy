// #ignore v4r o- : not yet implemented (unnecessary flag variable)

using System;

internal class CancellationTokenSource : IDisposable
{
	public void Dispose()
	{
	}
}

public class ExceptionHandling
{
	public void NoUsingStatementBecauseTheVariableIsAssignedTo()
	{
		CancellationTokenSource cancellationTokenSource = null;
		try
		{
			cancellationTokenSource = new CancellationTokenSource();
		}
		finally
		{
			if (cancellationTokenSource != null)
			{
				cancellationTokenSource.Dispose();
			}
		}
	}
}
