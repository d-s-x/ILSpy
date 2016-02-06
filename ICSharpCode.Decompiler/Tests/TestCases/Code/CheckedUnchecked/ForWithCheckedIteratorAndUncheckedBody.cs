using System;

public class CheckedUnchecked
{
	public void ForWithCheckedIteratorAndUncheckedBody(int n)
	{
		checked
		{
			for (int i = n + 1; i < n + 1; i++)
			{
				n = unchecked(i * i);
			}
		}
	}
}
