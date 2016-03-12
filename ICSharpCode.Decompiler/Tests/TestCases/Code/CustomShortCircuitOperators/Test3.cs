// #ignore v4r o- : not yet implemented

using System;

public static class CustomShortCircuitOperators
{
	// TODO: Restore base class after https://roslyn.codeplex.com/workitem/358 is fixed.
	private class C
	{
		public static bool operator true(CustomShortCircuitOperators.C x)
		{
			return true;
		}

		public static bool operator false(CustomShortCircuitOperators.C x)
		{
			return false;
		}

		public static CustomShortCircuitOperators.C operator &(CustomShortCircuitOperators.C x, CustomShortCircuitOperators.C y)
		{
			return null;
		}
		
		public static CustomShortCircuitOperators.C operator |(CustomShortCircuitOperators.C x, CustomShortCircuitOperators.C y)
		{
			return null;
		}
		
		public static bool operator !(CustomShortCircuitOperators.C x)
		{
			return false;
		}

		private static void Test3()
		{
			CustomShortCircuitOperators.C c = new CustomShortCircuitOperators.C();
			if (c)
			{
				Console.WriteLine(c.ToString());
			}
			if (!c)
			{
				Console.WriteLine(c.ToString());
			}
		}
	}
}
