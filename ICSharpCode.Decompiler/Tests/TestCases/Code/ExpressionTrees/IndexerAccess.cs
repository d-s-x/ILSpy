// #exclude v2 : compilation error
// #ignore v4r : not yet implemented

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
	
	public void IndexerAccess()
	{
		Dictionary<string, int> dict = Enumerable.Range(1, 20).ToDictionary((int n) => n.ToString());
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => dict["3"] == 3);
	}
}
