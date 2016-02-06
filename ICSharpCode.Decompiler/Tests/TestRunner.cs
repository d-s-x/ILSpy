// Copyright (c) AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System.Collections.Generic;
using System.Linq;
using ICSharpCode.Decompiler.Tests.TestCases;
using NUnit.Framework;

namespace ICSharpCode.Decompiler.Tests
{
	[TestFixture]
	public class TestRunner : DecompilerTestBase
	{
		[Test, TestCaseSource("GetCodeTestCases")]
		public void RunCode(List<string> lines, bool optimize, bool useDebug, CompilerVersion compiler)
		{
			AssertRoundtripCode(lines, optimize, useDebug, compiler);
		}

		public static IEnumerable<TestCaseData> GetCodeTestCases()
		{
			return CodeTestCaseReader.GetTestCases().Select(TransformTestCase);
		}

		private static TestCaseData TransformTestCase(CodeTestCase code)
		{
			var testData = new TestCaseData(code.Lines, code.Optimize, code.UseDebug, code.CompilerVersion);
			var dot = code.Name.IndexOf('.');
			testData.SetCategory("Decompilation/" + code.Name.Substring(0, dot));
			testData.SetName(code.Name.Substring(dot + 1));
			if (code.IgnoreReason != null)
			{
				testData.Ignore(code.IgnoreReason);
			}
			return testData;
		}
		
		[Test, Ignore("Missing cast on null")]
		public void DelegateConstruction()
		{
			TestFile(@"..\..\Tests\DelegateConstruction.cs");
		}
		
		[Test, Ignore("Not yet implemented")]
		public void ExpressionTrees()
		{
			TestFile(@"..\..\Tests\ExpressionTrees.cs");
		}
		
		[Test]
		public void ExceptionHandling()
		{
			AssertRoundtripCode(@"..\..\Tests\ExceptionHandling.cs", optimize: false);
			AssertRoundtripCode(@"..\..\Tests\ExceptionHandling.cs", optimize: false);
		}
		
		[Test]
		public void Generics()
		{
			TestFile(@"..\..\Tests\Generics.cs");
		}
		
		[Test]
		public void CustomShortCircuitOperators()
		{
			TestFile(@"..\..\Tests\CustomShortCircuitOperators.cs");
		}
		
		[Test]
		public void ControlFlowWithDebug()
		{
			AssertRoundtripCode(@"..\..\Tests\ControlFlow.cs", optimize: false, useDebug: true);
			AssertRoundtripCode(@"..\..\Tests\ControlFlow.cs", optimize: false, useDebug: true);
		}
		
		[Test]
		public void DoubleConstants()
		{
			TestFile(@"..\..\Tests\DoubleConstants.cs");
		}
		
		[Test]
		public void IncrementDecrement()
		{
			TestFile(@"..\..\Tests\IncrementDecrement.cs");
		}
		
		[Test]
		public void InitializerTests()
		{
			TestFile(@"..\..\Tests\InitializerTests.cs");
		}

		[Test]
		public void LiftedOperators()
		{
			TestFile(@"..\..\Tests\LiftedOperators.cs");
		}
		
		[Test]
		public void Loops()
		{
			TestFile(@"..\..\Tests\Loops.cs");
		}
		
		[Test]
		public void MultidimensionalArray()
		{
			TestFile(@"..\..\Tests\MultidimensionalArray.cs");
		}
		
		[Test]
		public void PInvoke()
		{
			TestFile(@"..\..\Tests\PInvoke.cs");
		}
		
		[Test]
		public void PropertiesAndEvents()
		{
			TestFile(@"..\..\Tests\PropertiesAndEvents.cs");
		}
		
		[Test]
		public void QueryExpressions()
		{
			TestFile(@"..\..\Tests\QueryExpressions.cs");
		}
		
		[Test, Ignore("switch transform doesn't recreate the exact original switch")]
		public void Switch()
		{
			TestFile(@"..\..\Tests\Switch.cs");
		}
		
		[Test]
		public void UndocumentedExpressions()
		{
			TestFile(@"..\..\Tests\UndocumentedExpressions.cs");
		}
		
		[Test, Ignore("has incorrect casts to IntPtr")]
		public void UnsafeCode()
		{
			TestFile(@"..\..\Tests\UnsafeCode.cs");
		}
		
		[Test]
		public void ValueTypes()
		{
			TestFile(@"..\..\Tests\ValueTypes.cs");
		}
		
		[Test, Ignore("Redundant yield break; not removed")]
		public void YieldReturn()
		{
			TestFile(@"..\..\Tests\YieldReturn.cs");
		}

		[Test]
		public void TypeAnalysis()
		{
			TestFile(@"..\..\Tests\TypeAnalysisTests.cs");
		}

		// see https://github.com/icsharpcode/ILSpy/pull/671
		[Test]
		public void NotUsingBlock()
		{
			TestFile(@"..\..\Tests\NotUsingBlock.cs");
		}

		static void TestFile(string fileName, bool useDebug = false, CompilerVersion compilerVersion = CompilerVersion.V4)
		{
			AssertRoundtripCode(fileName, optimize: false, useDebug: useDebug, compilerVersion: compilerVersion);
			AssertRoundtripCode(fileName, optimize: true, useDebug: useDebug, compilerVersion: compilerVersion);
			AssertRoundtripCode(fileName, optimize: false, useDebug: useDebug, compilerVersion: compilerVersion);
			AssertRoundtripCode(fileName, optimize: true, useDebug: useDebug, compilerVersion: compilerVersion);
		}
	}
}
