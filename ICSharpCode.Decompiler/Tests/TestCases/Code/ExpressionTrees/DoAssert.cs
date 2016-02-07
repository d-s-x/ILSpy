// #exclude v2 : compilation error
// #ignore : not yet implemented

using System;
using System.Linq.Expressions;

public class ExpressionTrees
{
	private int field;
	
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
	
	public void DoAssert()
	{
		this.field = 37;
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => this.field != this.C());
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => !object.ReferenceEquals(this, new ExpressionTrees()));
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => this.MyEquals(this) && !this.MyEquals(default(ExpressionTrees)));
	}
	
	private int C()
	{
		return this.field + 5;
	}
	
	private bool MyEquals(ExpressionTrees other)
	{
		return other != null && this.field == other.field;
	}
}
