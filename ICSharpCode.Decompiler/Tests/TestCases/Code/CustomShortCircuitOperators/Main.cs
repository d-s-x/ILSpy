// #ignore v4r : not yet implemented

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

		private static void Main()
		{
			CustomShortCircuitOperators.C c = new CustomShortCircuitOperators.C();
			CustomShortCircuitOperators.C c2 = new CustomShortCircuitOperators.C();
			CustomShortCircuitOperators.C c3 = c && c2;
			CustomShortCircuitOperators.C c4 = c || c2;
			Console.WriteLine(c3.ToString());
			Console.WriteLine(c4.ToString());
		}
	}
}
