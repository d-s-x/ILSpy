// #exclude v2 : compilation error
// #ignore : not yet implemented (char literal should'n be converted to int)

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
	
	public void CharNoCast()
	{
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => "abc"[1] == 'b');
	}
}
