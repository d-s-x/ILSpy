// #exclude v2 : compilation error
// #ignore v4 : not yet implemented (unnecessary linq)
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
	
	public void NestedLambda()
	{
		Func<Func<int>, int> call = (Func<int> f) => f();
		//no params
		ExpressionTrees.ToCode<int>(ExpressionTrees.X(), () => call(() => 42));
		//one param
		ExpressionTrees.ToCode<IEnumerable<int>>(ExpressionTrees.X(), () => new int[]
		{
			37,
			42
		}.Select(x => x * 2));
		//two params
		ExpressionTrees.ToCode<IEnumerable<int>>(ExpressionTrees.X(), () => new int[]
		{
			37,
			42
		}.Select((int x, int i) => x * 2));
	}
}
