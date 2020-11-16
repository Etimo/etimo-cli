using Etimo.Cli.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Etimo.Cli.Commands;
using Etimo.Cli.Tests.Factories;

namespace Etimo.Cli.Tests
{
    public class ArgumentParserTests
    {
        [Test]
        public void Parse_Uppercase_ShouldReturnLowerCaseCommandName()
        {
            var args = new List<string> { "TEST" };
            const string expectedCommand = "test";

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var commandName = parser.GetContext().Command.Name;

            Assert.AreEqual(expectedCommand, commandName);
        }

        [Test]
        public void Parse_Test_ShouldReturnTestCommandName()
        {
            var args = new List<string> { "test" };
            const string expectedCommand = "test";

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var commandName = parser.GetContext().Command.Name;

            Assert.AreEqual(expectedCommand, commandName);
        }

        [Test]
        public void Parse_NoArguments_ShouldReturnEmptyArguments()
        {
            var args = new List<string> { "test" };

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var arguments = parser.GetContext().Arguments;

            Assert.IsEmpty(arguments);
        }

        [Test]
        public void Parse_NoOptions_ShouldReturnEmptyOptions()
        {
            var args = new List<string> { "test" };

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var options = parser.GetContext().Options;

            Assert.IsEmpty(options);
        }

        [Test]
        public void Parse_TestNew_ShouldReturnNewTestCommandName()
        {
            var args = new List<string> { "test", "new" };
            const string expectedCommand = "test new";

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var commandName = parser.GetContext().Command.Name;

            Assert.AreEqual(expectedCommand, commandName);
        }

        [Test]
        public void Parse_TestNew_ShouldReturnTestFamilyName()
        {
            var args = new List<string> { "test", "new" };
            const string expectedFamily = "test";

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var familyName = parser.GetContext().Command.Family;

            Assert.AreEqual(expectedFamily, familyName);
        }

        [Test]
        public void Parse_TestNew_ShouldReturnEmptyArguments()
        {
            var args = new List<string> { "test", "new" };

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var arguments = parser.GetContext().Arguments;

            Assert.IsEmpty(arguments);
        }

        [Test]
        public void Parse_TestNew_ShouldReturnEmptyOptions()
        {
            var args = new List<string> { "test", "new" };

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var options = parser.GetContext().Options;

            Assert.IsEmpty(options);
        }

        [Test]
        public void Parse_TestNewWithTestOptionInTheMiddle_ShouldReturnTestCommand()
        {
            var args = new List<string> { "test", "--foo", "new" };
            const string expectedCommand = "test";

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var commandName = parser.GetContext().Command.Name;

            Assert.AreEqual(expectedCommand, commandName);
        }

        [Test]
        public void Parse_TestNewWithFooOptionInTheMiddle_ShouldReturnTestOption()
        {
            var args = new List<string> { "test", "--foo", "new" };
            const string expectedOption = "foo";

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var optionName = parser.GetContext().Options.First().Name;

            Assert.AreEqual(expectedOption, optionName);
        }

        [Test]
        public void Parse_FooOptions_ShouldReturnNoCommand()
        {
            var args = new List<string> { "--foo" };

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var command = parser.GetContext().Command;

            Assert.IsInstanceOf(typeof(NoCommand), command);
        }

        [Test]
        public void Parse_InvalidOptionsArgument_ShouldThrowArgumentException()
        {
            var args = new List<string> { "--invalid" };

            var parser = ArgumentParserFactory.CreateArgumentParser();

            Assert.Throws<ArgumentException>(() =>
            {
                parser.Parse(args);
            });
        }

        [Test]
        public void Parse_Help_ShouldReturnNullCommandName()
        {
            var args = new List<string> { "--help" };

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var commandName = parser.GetContext().Command.Name;

            Assert.Null(commandName);
        }

        [Test]
        public void Parse_Help_ShouldReturnHelpOptions()
        {
            var args = new List<string> { "--help" };

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var options = parser.GetContext().Options;

            Assert.AreEqual(typeof(HelpOption), options.FirstOrDefault()?.GetType());
        }

        [Test]
        public void Parse_Help_ShouldReturnEmptyArguments()
        {
            var args = new List<string> { "--help" };

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var arguments = parser.GetContext().Arguments;

            Assert.IsEmpty(arguments);
        }

        [Test]
        public void Parse_UppercaseHelp_ShouldReturnHelpOptions()
        {
            var args = new List<string> { "--HELP" };

            var parser = ArgumentParserFactory.CreateArgumentParser();
            parser.Parse(args);
            var option = parser.GetContext().Options.FirstOrDefault()?.GetType();

            Assert.AreEqual(typeof(HelpOption), option);
        }
    }
}
