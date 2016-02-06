// #ignore : unncessary primitive casts

using System;

public class CheckedUnchecked
{
	public int Cast(int a)
	{
		short num = checked((short)a);
		short num2 = (short)a;
		byte b = checked((byte)a);
		byte b2 = (byte)a;
		return num * num2 * b * b2;
	}
}
