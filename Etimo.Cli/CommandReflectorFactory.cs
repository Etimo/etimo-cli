using System.Collections.Generic;
using System.Linq;

namespace Etimo.Cli
{
    public class CommandReflectorFactory
    {
        public static CommandReflector Default => CreateCommandReflector(Namespaces.Commands);

        public static CommandReflector CreateCommandReflector(params string[] commandNamespaces)
            => new CommandReflector(commandNamespaces.ToList());

        public static CommandReflector CreateCommandReflector(List<string> commandNamespaces)
            => new CommandReflector(commandNamespaces);
    }
}
