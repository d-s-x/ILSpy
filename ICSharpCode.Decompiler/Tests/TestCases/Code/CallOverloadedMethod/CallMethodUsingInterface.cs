using System;
using System.Collections.Generic;

public class CallOverloadedMethod
{
	public void CallMethodUsingInterface(List<int> list)
	{
		((ICollection<int>)list).Clear();
	}
}
