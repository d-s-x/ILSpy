// #exclude v2 : compilation error
// #ignore v4  : not yet implemented
// #ignore v4r : not yet implemented

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

	public Action CaptureOfThisAndParameterInForEachWithItemCopy(int a)
	{
		foreach (int item in Enumerable.Empty<int>())
		{
			int copyOfItem = item;
			if (item > 0)
			{
				return delegate
				{
					this.CaptureOfThisAndParameter(item + a + copyOfItem);
				};
			}
		}
		return null;
	}
}
