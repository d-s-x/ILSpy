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
	
	private bool Fizz(Func<int, bool> a)
	{
		return a(42);
	}

	private bool Buzz(Func<int, bool> a)
	{
		return a(42);
	}

	private bool Fizz(Func<string, bool> a)
	{
		return a("42");
	}
	
	public void NestedLambda2()
	{
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => this.Fizz((string x) => x == "a"));
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => this.Fizz((int x) => x == 37));
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => this.Fizz((int x) => true));
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => this.Buzz((int x) => true));
	}
}
