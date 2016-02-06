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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ICSharpCode.Decompiler.Tests.TestCases
{
	internal static class CodeTestCaseReader
	{
		private static readonly string Namespace = typeof(CodeTestCaseReader).Namespace + ".Code.";

		private static readonly Regex ExcludeRegex =
			new Regex(@"^//\s*#exclude\s+(?<options>.*?)\s*:\s*(?<reason>.+?)\s*$");

		private static readonly Regex IgnoreRegex =
			new Regex(@"^//\s*#ignore\s+(?<options>.*?)\s*:\s*(?<reason>.+?)\s*$");

		private static readonly CompilerVersion[] CompilerVersions =
			Enumerable.Cast<CompilerVersion>(Enum.GetValues(typeof(CompilerVersion))).ToArray();

		private static readonly bool[] Bools = { false, true };

		public static IEnumerable<CodeTestCase> GetTestCases()
		{
			Assembly thisAssembly = Assembly.GetExecutingAssembly();

			return thisAssembly.GetManifestResourceNames()
				.Where(name => name.StartsWith(Namespace))
				.SelectMany(name => ParseTestsSuit(
					name: Path.ChangeExtension(name.Substring(Namespace.Length), null),
					stream: thisAssembly.GetManifestResourceStream(name)));
		}

		private static IEnumerable<CodeTestCase> ParseTestsSuit(string name, Stream stream)
		{
			var excludeOptions = new List<CodeTestCaseMatcher>();
			var ignoreOptions = new List<CodeTestCaseMatcher>();

			var lines = new List<string>();
			using (var reader = new StreamReader(stream))
			{
				for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
				{
					try
					{
						Match excludeDirective = ExcludeRegex.Match(line);
						if (excludeDirective.Success)
						{
							excludeOptions.Add(CreateOptionsMatcher(excludeDirective));
							continue;
						}
						Match ignoreDirective = IgnoreRegex.Match(line);
						if (ignoreDirective.Success)
						{
							ignoreOptions.Add(CreateOptionsMatcher(ignoreDirective));
							continue;
						}
					}
					catch (NotSupportedException ex)
					{
						throw new NotSupportedException(
							string.Format("Unable to parse line '{0}' ({1})", line, name),
							ex);
					}

					lines.Add(line);
				}
			}

			foreach (CompilerVersion compiler in CompilerVersions)
			foreach (bool optimize in Bools)
			foreach (bool useDebug in Bools)
			{
				var exclude = excludeOptions.FirstOrDefault(o => o.IsMatch(optimize, useDebug, compiler));
				if (exclude != null)
				{
					continue; // skip test case
				}

				string testName = string.Format("{0} ({1} {2} {3})",
					name,
					compiler,
					optimize ? "o+" : "o−",
					useDebug ? "d+" : "d−");

				var ignore = ignoreOptions.FirstOrDefault(o => o.IsMatch(optimize, useDebug, compiler));
				string ignoreReason = ignore == null ? null : ignore.Reason;
						
				var testData = new CodeTestCase(testName, lines, optimize, useDebug, compiler, ignoreReason);
				yield return testData;
			}
		}

		private static CodeTestCaseMatcher CreateOptionsMatcher(Match match)
		{
			return new CodeTestCaseMatcher(match.Groups["options"].Value, match.Groups["reason"].Value);
		}
	}
}
