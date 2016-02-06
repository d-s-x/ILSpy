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

using System;

namespace ICSharpCode.Decompiler.Tests.TestCases
{
	internal class CodeTestCaseMatcher
	{
		private readonly string reason;

		private readonly bool? optimize;
		private readonly bool? useDebug;
		private readonly CompilerVersion? compilerVersion;

		public CodeTestCaseMatcher(string options, string reason)
		{
			foreach (string option in options.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
			{
				switch (option)
				{
					case "o+": optimize = true; break;
					case "o-": optimize = false; break;

					case "d+": useDebug = true; break;
					case "d-": useDebug = false; break;

					case "v2": compilerVersion = CompilerVersion.V2; break;
					case "v4": compilerVersion = CompilerVersion.V4; break;
					case "v4r": compilerVersion = CompilerVersion.V4Roslyn; break;

					default:
						throw new NotSupportedException("Unknown option: " + option);
				}
			}

			this.reason = reason;
		}

		public string Reason
		{
			get { return reason; }
		}

		public bool IsMatch(bool optimize, bool useDebug, CompilerVersion compilerVersion)
		{
			return (this.optimize == null || this.optimize == optimize)
				&& (this.useDebug == null || this.useDebug == useDebug)
				&& (this.compilerVersion == null || this.compilerVersion == compilerVersion);
		}
	}
}