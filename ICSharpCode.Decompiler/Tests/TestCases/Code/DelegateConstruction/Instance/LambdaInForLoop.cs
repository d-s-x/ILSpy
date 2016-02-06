// #exclude v2 : compilation error

using System;

public class InstanceTests
{
	public void LambdaInForLoop()
	{
		for (int i = 0; i < 100000; i++)
		{
			this.Bar(() => this.Foo());
		}
	}

	public int Foo()
	{
		return 0;
	}

	public void Bar(Func<int> f)
	{
	}
}
