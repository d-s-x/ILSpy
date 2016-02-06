// #exclude v2 : compilation error

using System;

public static class DelegateConstruction
{
	public static void Test(this string a)
	{
	}

	public static Action<string> ExtensionMethodUnbound()
	{
		return new Action<string>(DelegateConstruction.Test);
	}
}
