// #ignore v4r o- : not yet implemented (unnecessary flag variable)

using System;
using System.Collections.Generic;

public static class Generics
{
	public class MyArray<T>
	{
		public class NestedClass<Y>
		{
			public T Item1;
			public Y Item2;
		}
		
		public enum NestedEnum
		{
			A,
			B
		}
		
		private T[] arr;
		
		public MyArray(int capacity)
		{
			this.arr = new T[capacity];
		}
		
		public void Size(int capacity)
		{
			Array.Resize<T>(ref this.arr, capacity);
		}
		
		public void Grow(int capacity)
		{
			if (capacity >= this.arr.Length)
			{
				this.Size(capacity);
			}
		}
	}
	
	public interface IInterface
	{
		void Method1<T>() where T : class;
		void Method2<T>() where T : class;
	}
	
	public abstract class Base : Generics.IInterface
	{
		// constraints must be repeated on implicit interface implementation
		public abstract void Method1<T>() where T : class;
		
		// constraints must not be specified on explicit interface implementation
		void Generics.IInterface.Method2<T>()
		{
		}
	}
	
	public class Derived : Generics.Base
	{
		// constraints are inherited automatically and must not be specified
		public override void Method1<T>()
		{
		}
	}
	
	private const Generics.MyArray<string>.NestedEnum enumVal = Generics.MyArray<string>.NestedEnum.A;
	private static Type type1 = typeof(List<>);
	private static Type type2 = typeof(Generics.MyArray<>);
	private static Type type3 = typeof(List<>.Enumerator);
	private static Type type4 = typeof(Generics.MyArray<>.NestedClass<>);
	private static Type type5 = typeof(List<int>[]);
	private static Type type6 = typeof(Generics.MyArray<>.NestedEnum);

	public static Dictionary<string, string>.KeyCollection.Enumerator GetEnumerator(Dictionary<string, string> d, Generics.MyArray<string>.NestedClass<int> nc)
	{
		// Tests references to inner classes in generic classes
		return d.Keys.GetEnumerator();
	}
}
