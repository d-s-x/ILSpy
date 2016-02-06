// #exclude v2 : compilation error
// #ignore v4  : not yet implemented (foreach not recognized)
// #ignore v4r : not yet implemented (foreach not recognized)

using System;
using System.Linq;

public class InstanceTests
{
	public Action CaptureOfThisAndParameter(int a)
	{
		return delegate
		{
			this.CaptureOfThisAndParameter(a);
		};
	}

	public Action CaptureOfThisAndParameterInForEach(int a)
	{
		foreach (int item in Enumerable.Empty<int>())
		{
			if (item > 0)
			{
				return delegate
				{
					this.CaptureOfThisAndParameter(item + a);
				};
			}
		}
		return null;
	}
}
