// #exclude v2 : compilation error

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

	public void ArrayLengthAndDoubles()
	{
		ExpressionTrees.ToCode<int>(ExpressionTrees.X(), () => new double[]
		{
			1.0,
			2.01,
			3.5
		}.Concat(new double[]
		{
			1.0,
			2.0
		}).ToArray<double>().Length);
	}
}
