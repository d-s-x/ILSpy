// #exclude v2 : compilation error
// #ignore : not yet implemented

using System;
using System.Collections.Generic;
using System.Linq;
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
	
	public void MethodGroupConstant()
	{
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => Array.TrueForAll<int>(new int[]
		{
			2000,
			2004,
			2008,
			2012
		}, DateTime.IsLeapYear));
		
		HashSet<int> set = new HashSet<int>();
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => new int[]
		{
			2000,
			2004,
			2008,
			2012
		}.All(set.Add));
		
		Func<Func<object, object, bool>, bool> sink = f => f(null, null);
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => sink(int.Equals));
	}
}
