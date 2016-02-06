// #exclude v2 : compilation error

using System;

public static class DelegateConstruction
{
	public static Func<int, Func<int, Func<int, int>>> CurriedAddition2(int a)
	{
		return (int b) => (int c) => (int d) => a + b + c + d;
	}
}
