// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

using System;

public class CheckedUnchecked
{
	public void ArrayInitializerChecked() 
	{
		this.TestHelp<int[]>(new int[]
		{
			1,
			2
		}, (int[] n) => checked(new int[]
		{
			n[0] + 1,
			n[1] + 1
		}));
	}

	public T TestHelp<T>(T t, Func<T, T> f)
	{
		return f(t);
	}
}
