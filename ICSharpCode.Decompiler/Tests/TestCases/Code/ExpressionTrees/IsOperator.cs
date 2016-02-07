// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

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
	
	public void IsOperator()
	{
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => new object() is string);
	}
}
