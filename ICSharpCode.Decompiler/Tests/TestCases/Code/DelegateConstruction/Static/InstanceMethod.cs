// #exclude v2 : compilation error

using System;

public static class DelegateConstruction
{
	public static object InstanceMethod()
	{
		return new Func<string>("hello".ToUpper);
	}
}
