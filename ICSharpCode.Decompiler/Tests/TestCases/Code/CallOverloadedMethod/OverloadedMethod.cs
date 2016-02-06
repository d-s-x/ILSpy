// #ignore : disambiguating overloads is not yet implemented

using System;

public class CallOverloadedMethod
{
	public void OverloadedMethod(object a)
	{
	}
	
	public void OverloadedMethod(int? a)
	{
	}
	
	public void OverloadedMethod(string a)
	{
	}
	
	public void Call()
	{
		this.OverloadedMethod("(string)");
		this.OverloadedMethod((object)"(object)");
		this.OverloadedMethod(5);
		this.OverloadedMethod((object)5);
		this.OverloadedMethod(5L);
		this.OverloadedMethod((object)null);
		this.OverloadedMethod((string)null);
		this.OverloadedMethod((int?)null);
	}
}
