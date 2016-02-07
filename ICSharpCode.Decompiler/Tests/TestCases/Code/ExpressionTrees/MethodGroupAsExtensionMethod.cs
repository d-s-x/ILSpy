// #exclude v2 : compilation error
// #ignore : not yet implemented

using System;
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
	
	public void MethodGroupAsExtensionMethod()
	{
		ExpressionTrees.ToCode<Func<bool>>(ExpressionTrees.X(), () => (Func<bool>)new int[]
		{
			2000,
			2004,
			2008,
			2012
		}.Any);
	}
}
