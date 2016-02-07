// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

using System;
using System.Collections.Generic;
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
	
	public void ListInitializer3()
	{
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => new List<int>
		{
			1,
			2,
			3
		}.Count == 3);
	}
}
