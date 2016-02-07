// #exclude v2 : compilation error

using System;
using System.Linq.Expressions;

public class ExpressionTrees
{
	private class GenericClass<X>
	{
		public static X StaticField;
		public X InstanceField;
		public static X StaticProperty
		{
			get;
			set;
		}
		public X InstanceProperty
		{
			get;
			set;
		}

		public static bool GenericMethod<Y>()
		{
			return false;
		}
	}

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
	
	public void InvokeGenericMethod()
	{
		ExpressionTrees.ToCode<bool>(ExpressionTrees.X(), () => ExpressionTrees.GenericClass<int>.GenericMethod<double>());
	}
}
