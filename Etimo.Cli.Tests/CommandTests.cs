using Etimo.Cli.Tool.Tests.Commands;
using NUnit.Framework;

namespace Etimo.Cli.Tool.Tests
{
    public class CommandTests
    {
        [Test]
        public void Description_ShouldMatchDescriptionAttribute()
        {
            var command = new TestCommand();
            const string expectedDescription = "A simple test command";

            Assert.AreEqual(expectedDescription, command.Description);
        }

        [Test]
        public void Name_ShouldMatchNameAttribute()
        {
            var command = new TestCommand();
            const string expectedCommandName = "test";

            Assert.AreEqual(expectedCommandName, command.Name);
        }

        [Test]
        public void Family_ShouldMatchFamilyAttribute()
        {
            var command = new NewTestCommand();
            const string expectedFamily = "test";

            Assert.AreEqual(expectedFamily, command.Family);
        }
    }
}
