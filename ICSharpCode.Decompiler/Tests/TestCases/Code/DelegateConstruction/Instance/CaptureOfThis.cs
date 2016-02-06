// #exclude v2 : compilation error

using System;

public class InstanceTests
{
	public Action CaptureOfThis()
	{
		return delegate
		{
			this.CaptureOfThis();
		};
	}
}
