using System.Collections.Generic;

namespace Etimo.Cli.Abstractions
{
    public interface ICommandReflector
    {
        IEnumerable<ICommand> GetCommands();
    }
}
