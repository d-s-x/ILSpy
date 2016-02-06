using NUnit.Framework;

namespace ICSharpCode.Decompiler.Tests.Types
{
	[TestFixture]
	public class TypeTests : DecompilerTestBase
	{
		[Test]
		public void TypeMemberDeclarations()
		{
			AssertRoundtripCode(@"..\..\Tests\Types\S_TypeMemberDeclarations.cs");
		}
	}
}
