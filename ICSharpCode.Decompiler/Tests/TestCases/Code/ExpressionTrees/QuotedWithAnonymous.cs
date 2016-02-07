// #exclude v2 : compilation error
// #ignore v4 : not yet implemented (unnecessary linq)
// #ignore v4r : not yet implemented (unnecessary linq)

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
	
	public void QuotedWithAnonymous()
	{
		ExpressionTrees.ToCode<string>(ExpressionTrees.X(), () => new[]
		{
			new
			{
				X = "a",
				Y = "b"
			}
		}.Select(o => o.X + o.Y).Single<string>());
	}
}
