using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ICSharpCode.Decompiler.Tests.Types
{
	[TestFixture]
	public class EnumTests : DecompilerTestBase
	{
		[Test]
		public void EnumSamples()
		{
			AssertRoundtripCode(@"..\..\Tests\Types\S_EnumSamples.cs");
		}
	}
}
