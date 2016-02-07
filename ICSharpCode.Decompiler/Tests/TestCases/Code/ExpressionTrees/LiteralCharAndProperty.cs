// #exclude v2 : compilation error

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
	
	public void LiteralCharAndProperty()
	{
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => new string(' ', 3).Length == 1);
	}
}
