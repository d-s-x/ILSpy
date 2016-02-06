// #exclude v2 : compilation error

using System;

public class InstanceTests
{
	public Action CaptureOfThisAndParameter(int a)
	{
		return delegate
		{
			this.CaptureOfThisAndParameter(a);
		};
	}
}
