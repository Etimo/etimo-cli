using Etimo.Cli.Tests.Commands;
using Etimo.Cli.Tests.Options;
using NUnit.Framework;

namespace Etimo.Cli.Tests
{
    public class OptionTests
    {
        [Test]
        public void Description_ShouldMatchDescriptionAttribute()
        {
            var option = new FooOption();
            const string expectedDescription = "Foo option";

            Assert.AreEqual(expectedDescription, option.Description);
        }

        [Test]
        public void Name_ShouldMatchNameAttribute()
        {
            var option = new FooOption();
            const string expectedName = "foo";

            Assert.AreEqual(expectedName, option.Name);
        }

        [Test]
        public void ShortName_ShouldMatchFamilyAttribute()
        {
            var option = new FooOption();
            const string expectedShortName = "f";

            Assert.AreEqual(expectedShortName, option.ShortName);
        }
    }
}
