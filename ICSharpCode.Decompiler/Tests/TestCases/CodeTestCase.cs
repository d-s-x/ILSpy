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

namespace ICSharpCode.Decompiler.Tests.TestCases
{
	internal class CodeTestCase
	{
		private readonly string name;
		private readonly List<string> lines;
		private readonly bool optimize;
		private readonly bool useDebug;
		private readonly CompilerVersion compilerVersion;
		private readonly string ignoreReason;

		public CodeTestCase(
			string name,
			List<string> lines,
			bool optimize,
			bool useDebug,
			CompilerVersion compilerVersion,
			string ignoreReason = null)
		{
			this.name = name;
			this.lines = lines;
			this.optimize = optimize;
			this.useDebug = useDebug;
			this.compilerVersion = compilerVersion;
			this.ignoreReason = ignoreReason;
		}

		public string Name
		{
			get { return name; }
		}

		public List<string> Lines
		{
			get { return lines; }
		}

		public bool Optimize
		{
			get { return optimize; }
		}

		public bool UseDebug
		{
			get { return useDebug; }
		}

		public CompilerVersion CompilerVersion
		{
			get { return compilerVersion; }
		}

		public string IgnoreReason
		{
			get { return ignoreReason; }
		}
	}
}