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
	
	public void MembersBuiltin()
	{
		ExpressionTrees.ToCode<string>(ExpressionTrees.X(), () => 1.23m.ToString());
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => AttributeTargets.All.HasFlag((Enum)AttributeTargets.Assembly));
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => "abc".Length == 3);
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => 'a'.CompareTo('b') < 0);
	}
}
