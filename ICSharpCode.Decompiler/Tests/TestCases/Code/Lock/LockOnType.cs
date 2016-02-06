// #ignore v4r : not yet implemented

using System;

public class Lock
{
	public void LockOnType()
	{
		lock (typeof(Lock))
		{
			Console.WriteLine();
		}
	}
}
