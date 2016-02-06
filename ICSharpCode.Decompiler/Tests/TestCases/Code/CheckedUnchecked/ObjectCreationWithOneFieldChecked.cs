// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

using System;

public class CheckedUnchecked
{
	public void ObjectCreationWithOneFieldChecked() 
	{
		this.TestHelp(new 
		{
			x = 0,
			l = 0
		}, n => new 
		{
			x = checked(n.x + 1), 
			l = n.l + 1 
		});
	}

	public T TestHelp<T>(T t, Func<T, T> f)
	{
		return f(t);
	}
}
