using System.Collections.Generic;
using System.Linq;

namespace Etimo.Cli
{
    public class OptionReflectorFactory
    {
        public static OptionReflector Default => CreateOptionReflector(Namespaces.Options);

        public static OptionReflector CreateOptionReflector(params string[] optionNamespaces)
            => new OptionReflector(optionNamespaces.ToList());

        public static OptionReflector CreateOptionReflector(List<string> optionNamespace)
            => new OptionReflector(optionNamespace);
    }
}
