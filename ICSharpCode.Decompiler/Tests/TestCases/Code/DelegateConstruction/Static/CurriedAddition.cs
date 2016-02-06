// #exclude v2 : compilation error

using System;

public static class DelegateConstruction
{
	public static Func<int, Func<int, int>> CurriedAddition(int a)
	{
		return (int b) => (int c) => a + b + c;
	}
}
