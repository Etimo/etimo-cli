using Etimo.Cli.Abstractions;
using Etimo.Cli.Commands;
using Etimo.Cli.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Etimo.Cli
{
    public class ArgumentParser : IArgumentParser
    {
        private readonly ICommandReflector _commandReflector;
        private readonly IOptionReflector _optionReflector;

        private ExecutionContext _executionContext;

        public ArgumentParser(
            ICommandReflector commandReflector = null,
            IOptionReflector optionReflector = null)
        {
            _commandReflector = commandReflector ?? CommandReflectorFactory.Default;
            _optionReflector = optionReflector ?? OptionReflectorFactory.Default;
        }

        public virtual IArgumentParser Parse(List<string> arguments)
        {
            _executionContext = new ExecutionContext();
            arguments ??= new List<string>();
            ParseProgramArguments(arguments.ToList());
            ParseArguments(arguments.ToList());
            ParseOptions(arguments.ToList());
            ParseCommand(arguments.ToList());

            return this;
        }

        public IExecutionContext GetContext()
        {
            return _executionContext;
        }

        private void ParseProgramArguments(List<string> arguments)
        {
            _executionContext.ProgramArguments = arguments.ToList();
        }

        private void ParseArguments(List<string> arguments)
        {
            var commandName = GetCommand(arguments)?.Name;

            _executionContext.Arguments = RemoveCommand(commandName, RemoveOptions(arguments));
        }

        private void ParseOptions(List<string> arguments)
        {
            var availableOptions = GetAvailableOptions();

            // Now loop through the arguments to make sure everything
            // that is an option argument has a matching Option
            var options = new List<IOption>();
            foreach (var argument in arguments.Where(IsOption))
            {
                if (argument == null) continue;

                var optionName = GetOptionName(argument);
                if (availableOptions.ContainsKey(optionName))
                {
                    availableOptions[optionName].Value = GetOptionValue(argument);
                    var option = availableOptions[optionName];
                    option.Context = _executionContext;
                    options.Add(option);
                }
                else
                {
                    throw new ArgumentException("Invalid options key", optionName);
                }
            }

            _executionContext.Options = options;
        }

        private void ParseCommand(List<string> arguments)
        {
            _executionContext.Command = GetCommand(arguments);
        }

        private ICommand GetCommand(List<string> arguments)
        {
            var argumentsWithoutOptions = RemoveOptions(arguments);
            var commandVariations = CompileCommandVariations(argumentsWithoutOptions);

            if (!commandVariations.Any())
            {
                return new NoCommand();
            }

            var commands = _commandReflector.GetCommands().ToList();
            foreach (var command in commandVariations)
            {
                var foundCommand = commands.FirstOrDefault(c => string.Equals(c.Name, command, StringComparison.InvariantCultureIgnoreCase));
                if (foundCommand != null)
                {
                    return foundCommand;
                }
            }

            return new NotFoundCommand();
        }

        private Dictionary<string, Option> GetAvailableOptions()
        {
            var allOptions = _optionReflector.GetOptions();
            var availableOptions = new Dictionary<string, Option>();
            foreach (var option in allOptions)
            {
                var optionImpl = option as Option;
                if (optionImpl?.Name != null) availableOptions.Add($"--{option.Name}", optionImpl);
                if (optionImpl?.ShortName != null) availableOptions.Add($"-{option.ShortName}", optionImpl);
            }

            return availableOptions;
        }

        private static string GetOptionValue(string argument)
        {
            var optionParts = argument.Split("=");

            string optionValue = null;
            if (optionParts.Length > 1)
            {
                optionValue = string.Join(" ", optionParts.Skip(1));
            }

            return optionValue;
        }

        private static string GetOptionName(string argument)
        {
            var optionParts = argument.Split("=");

            // Remove all hyphens from the beginning of the name
            return optionParts.First().ToLowerInvariant();
        }

        private static List<string> RemoveOptions(List<string> arguments)
        {
            var commandIndex = arguments.FindIndex(arg => !arg.StartsWith("-"));
            if (commandIndex > -1)
            {
                return arguments.Skip(commandIndex).ToList();
            }

            return new List<string>();
        }

        private static List<string> RemoveCommand(string commandToRemove, List<string> arguments)
        {
            if (commandToRemove == null)
            {
                return arguments;
            }

            var commands = commandToRemove.Split(" ");
            foreach (var command in commands)
            {
                arguments.Remove(command);
            }

            return arguments;
        }

        private static List<string> CompileCommandVariations(List<string> candidates)
        {
            var result = new List<string>();
            for (var i = candidates.Count - 1; i >= 0; i--)
            {
                result.Add(string.Join(" ", candidates));
                candidates.RemoveAt(i);
            }

            return result;
        }

        private static bool IsOption(string argument)
        {
            return argument.StartsWith("-");
        }
    }
}
