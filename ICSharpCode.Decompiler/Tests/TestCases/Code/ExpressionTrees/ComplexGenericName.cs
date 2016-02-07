﻿// #exclude v2 : compilation error

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
	
	public void ComplexGenericName()
	{
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => ((Func<int, bool>)((int x) => x > 0))(0));
	}
}
