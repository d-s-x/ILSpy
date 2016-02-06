// #exclude v2 : compilation error
// #ignore v4  : not yet implemented (missing cast on null)
// #ignore v4r : not yet implemented (missing cast on null)

using System;

public static class DelegateConstruction
{
	public static object InstanceMethodOnNull()
	{
		return new Func<string>(((string)null).ToUpper);
	}
}
