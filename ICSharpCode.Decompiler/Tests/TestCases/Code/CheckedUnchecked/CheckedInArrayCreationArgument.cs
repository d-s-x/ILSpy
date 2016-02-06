using System;

public class CheckedUnchecked
{
	public void CheckedInArrayCreationArgument(int a, int b)
	{
		Console.WriteLine(new int[checked(a + b)]);
	}
}
