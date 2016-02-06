// #exclude v2 : compilation error

using System;

public static class DelegateConstruction
{
	public static void Test(this string a)
	{
	}

	public static Action ExtensionMethodBound()
	{
		return new Action("abc".Test);
	}

	public static object StaticMethod()
	{
		return new Func<Action>(DelegateConstruction.ExtensionMethodBound);
	}
}
