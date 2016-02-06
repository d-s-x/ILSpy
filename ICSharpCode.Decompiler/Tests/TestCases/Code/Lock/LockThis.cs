using System;

public class Lock
{
	public void LockThis()
	{
		lock (this)
		{
			Console.WriteLine();
		}
	}
}
