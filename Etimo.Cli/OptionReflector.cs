using Etimo.Cli.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Etimo.Cli
{
    public class OptionReflector : IOptionReflector
    {
        private readonly List<string> _namespaces;

        public OptionReflector(List<string> namespaces = null)
        {
            _namespaces = namespaces ?? new List<string>();

            // Make sure we include the built-in options namespaces
            if (!_namespaces.Contains(Namespaces.Options))
            {
                _namespaces.Add(Namespaces.Options);
            }
        }

        public IEnumerable<IOption> GetOptions()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            var assembliesWithCommands = assemblies.Where(a =>
                a.DefinedTypes.Any(t =>
                    _namespaces.Any(n =>
                        t.FullName.StartsWith(n))));

            return assembliesWithCommands.SelectMany(GetOptionsForAssembly);
        }

        public List<IOption> GetOptionsForAssembly(Assembly assembly)
        {
            // Get all the types within the Options namespace
            var types = assembly.DefinedTypes.Where(t => _namespaces.Any(n => t.FullName.StartsWith(n)));
            var options = new List<IOption>();
            foreach (var type in types)
            {
                // Make sure the type is not abstract and can be instantiated to an IOptions object
                if (!type.IsAbstract && Activator.CreateInstance(type) is IOption instance)
                {
                    options.Add(instance);
                }
            }

            return options;
        }
    }
}
