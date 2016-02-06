using NUnit.Framework;

namespace ICSharpCode.Decompiler.Tests.CustomAttributes
{
	[TestFixture]
	public class CustomAttributeTests : DecompilerTestBase
	{
		[Test]
		public void CustomAttributeSamples()
		{
			AssertRoundtripCode(@"..\..\Tests\CustomAttributes\S_CustomAttributeSamples.cs");
		}

		[Test]
		public void CustomAttributesMultiTest()
		{
			AssertRoundtripCode(@"..\..\Tests\CustomAttributes\S_CustomAttributes.cs");
		}

		[Test]
		public void AssemblyCustomAttributesMultiTest()
		{
			AssertRoundtripCode(@"..\..\Tests\CustomAttributes\S_AssemblyCustomAttribute.cs");
		}
	}
}
