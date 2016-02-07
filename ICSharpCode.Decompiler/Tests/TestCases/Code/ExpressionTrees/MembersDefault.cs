// #exclude v2 : compilation error
// #ignore : not yet implemented (default value of reference type shouldn't turn into null)

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	
	public void MembersDefault()
	{
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => default(DateTime).Ticks == 0L);
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => default(int[]).Length == 0);
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => default(Type).IsLayoutSequential);
		ExpressionTrees.ToCode<int>(ExpressionTrees.X(), () => default(List<int>).Count);
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => default(int[]).Clone() == null);
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => default(Type).IsInstanceOfType(new object()));
		ExpressionTrees.ToCode<ReadOnlyCollection<int>>(ExpressionTrees.X(), () => default(List<int>).AsReadOnly());
	}
}
