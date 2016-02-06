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
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using ICSharpCode.Decompiler.Ast;
using ICSharpCode.Decompiler.Tests.Helpers;
using Mono.Cecil;
using LegacyCSharpCodeProvider = Microsoft.CSharp.CSharpCodeProvider;
using RoslynCSharpCodeProvider = Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider;

namespace ICSharpCode.Decompiler.Tests
{
	public abstract class DecompilerTestBase
	{
		static string RemoveIgnorableLines(IEnumerable<string> lines)
		{
			return CodeSampleFileParser.ConcatLines(lines.Where(l => !CodeSampleFileParser.IsCommentOrBlank(l)));
		}

		protected static void AssertRoundtripCode(string fileName, bool optimize = false, bool useDebug = false, CompilerVersion compilerVersion = CompilerVersion.V4)
		{
			var code = RemoveIgnorableLines(File.ReadLines(fileName));
			AssemblyDefinition assembly = CompileLegacy(code, optimize, useDebug, compilerVersion);

			AssertAssembly(assembly, code);
		}

		protected static void AssertAssembly(string compiledFile, string expectedOutputFile)
		{
			string expectedOutput = File.ReadAllText(expectedOutputFile);
			AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(compiledFile);

			AssertAssembly(assembly, expectedOutput);
		}

		private static void AssertAssembly(AssemblyDefinition assembly, string expectedOutput)
		{
			AstBuilder decompiler = new AstBuilder(new DecompilerContext(assembly.MainModule));
			decompiler.AddAssembly(assembly);
			new Helpers.RemoveCompilerAttribute().Run(decompiler.SyntaxTree);

			StringWriter output = new StringWriter();
			decompiler.GenerateCode(new PlainTextOutput(output));
			CodeAssert.AreEqual(expectedOutput, output.ToString());
		}

		private static AssemblyDefinition CompileLegacy(string code, bool optimize, bool useDebug, CompilerVersion compilerVersion)
		{
			CodeDomProvider provider = GetCompiler(compilerVersion);
			CompilerParameters options = GetCompilerOptions(optimize, useDebug, compilerVersion);

			CompilerResults results = provider.CompileAssemblyFromSource(options, code);
			try
			{
				if (results.Errors.Count > 0)
				{
					StringBuilder b = new StringBuilder("Compiler error:");
					foreach (var error in results.Errors)
					{
						b.AppendLine(error.ToString());
					}
					throw new Exception(b.ToString());
				}
				return AssemblyDefinition.ReadAssembly(results.PathToAssembly);
			}
			finally
			{
				File.Delete(results.PathToAssembly);
				results.TempFiles.Delete();
			}
		}

		private static CodeDomProvider GetCompiler(CompilerVersion compilerVersion)
		{
			switch (compilerVersion)
			{
				case CompilerVersion.V2: 
					return new LegacyCSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v2.0" } });

				case CompilerVersion.V4:
					return new LegacyCSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } });

				case CompilerVersion.V4Roslyn:
					return new RoslynCSharpCodeProvider();

				default:
					throw new NotImplementedException("Unknown compiler version " + compilerVersion);
			}
		}

		protected static CompilerParameters GetCompilerOptions(bool optimize, bool useDebug, CompilerVersion compilerVersion)
		{
			CompilerParameters options = new CompilerParameters();
			options.CompilerOptions = "/unsafe /o" + (optimize ? "+" : "-") + (useDebug ? " /debug" : "");
			switch (compilerVersion)
			{
				case CompilerVersion.V2:
					break;

				case CompilerVersion.V4:
				case CompilerVersion.V4Roslyn:
					options.ReferencedAssemblies.Add("System.Core.dll");
					break;

				default:
					throw new NotImplementedException("Unknown compiler version " + compilerVersion);
			}
			return options;
		}

		public enum CompilerVersion
		{
			V2,
			V4,
			V4Roslyn,
		}
	}
}
