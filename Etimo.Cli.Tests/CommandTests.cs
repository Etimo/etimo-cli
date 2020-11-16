using Etimo.Cli.Abstractions;
using Etimo.Cli.Tests.Commands;
using Etimo.Cli.Tests.Factories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Etimo.Cli.Tests
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

        private static ICommand GetCommand(params string[] args)
        {
            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args.ToList());
            return parser.GetContext().Command;
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

        [Test]
        public void GetFamilyMembers_NewTestCommand_ShouldReturnNonEmptyList()
        {
            var command = GetCommand("test", "new");

            var familyMembers = command.GetFamilyMembers();

            Assert.IsNotEmpty(familyMembers);
        }

        [Test]
        public void GetFamilyMembers_NewTestCommand_ShouldReturnTestFamilyMembers()
        {
            var command = GetCommand("test", "new");

            var familyMembers = command.GetFamilyMembers();

            Assert.IsTrue(familyMembers.All(m => m.Family == "test"));
        }

        [Test]
        public void GetFamilyMembers_TestWithoutFamilyCommand_ShouldReturnNoFamilyMembers()
        {
            var command = GetCommand("test2");

            var familyMembers = command.GetFamilyMembers();

            Assert.IsEmpty(familyMembers);
        }
    }
}
