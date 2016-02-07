// #exclude v2 : compilation error
// #ignore v4 : not yet implemented (logical negation of numeric value)
// #ignore v4r : not yet implemented (logical negation of numeric value)

using System;
using System.Linq.Expressions;

public class ExpressionTrees
{
	private static object ToCode<R>(object x, Expression<Func<R>> expr)
	{
		return expr;
	}
	
	private static object ToCode<T, R>(object x, Expression<Func<T, R>> expr)
	{
		return expr;
	}
	
	private static object X()
	{
		return null;
	}
	
	public void NotImplicitCast()
	{
		byte z = 42;
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => ~z == 0);
	}
}
