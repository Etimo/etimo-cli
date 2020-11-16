using System.Collections.Generic;

namespace Etimo.Cli.Abstractions
{
    public interface IArgumentParser
    {
        IArgumentParser Parse(List<string> arguments);
        IExecutionContext GetContext();
        ICommandReflector CommandReflector { get; }
        IOptionReflector OptionReflector { get; }
    }
}
