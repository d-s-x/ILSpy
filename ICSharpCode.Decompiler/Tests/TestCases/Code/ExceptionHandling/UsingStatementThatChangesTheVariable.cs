using System;

internal class CancellationTokenSource : IDisposable
{
	public void Dispose()
	{
	}
}

public class ExceptionHandling
{
	public IDisposable UsingStatementThatChangesTheVariable()
	{
		CancellationTokenSource cancellationTokenSource = null;
		using (cancellationTokenSource)
		{
			cancellationTokenSource = new CancellationTokenSource();
		}
		return cancellationTokenSource;
	}
}
