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
	
	public void Strings()
	{
		int i = 1;
		string x = "X";
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => ((("a\n\\b" ?? x) + x).Length == 2) ? false : (true && (1m + (decimal)(-i) > 0m || false)));
	}
}
