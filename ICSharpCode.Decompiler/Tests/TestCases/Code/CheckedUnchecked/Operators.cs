// #ignore v4r o+ : not yet implemented

using System;

public class CheckedUnchecked
{
	public int Operators(int a, int b)
	{
		int num = checked(a + b);
		int num2 = a + b;
		int num3 = checked(a - b);
		int num4 = a - b;
		int num5 = checked(a * b);
		int num6 = a * b;
		int num7 = a / b;
		int num8 = a % b;
		// The division operators / and % only exist in one form (checked vs. unchecked doesn't matter for them)
		return num * num2 * num3 * num4 * num5 * num6 * num7 * num8;
	}
}
