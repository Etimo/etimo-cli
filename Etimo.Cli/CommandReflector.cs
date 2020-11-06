using Etimo.Cli.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Etimo.Cli
{
    public class CommandReflector : ICommandReflector
    {
        private readonly List<string> _namespaces;

        public CommandReflector(List<string> namespaces = null)
        {
            _namespaces = namespaces ?? new List<string>();

            // Make sure we include the built-in command namespaces
            if (!_namespaces.Contains(Namespaces.Commands))
            {
                _namespaces.Add(Namespaces.Commands);
            }
        }

        public IEnumerable<ICommand> GetCommands()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            var assembliesWithCommands = assemblies.Where(a =>
                a.DefinedTypes.Any(t =>
                    _namespaces.Any(n =>
                        t.FullName.StartsWith(n))));

            return assembliesWithCommands.SelectMany(GetCommandsForAssembly);
        }

        private IEnumerable<ICommand> GetCommandsForAssembly(Assembly assembly)
        {
            var types = assembly.DefinedTypes
                .Where(t =>
                    _namespaces.Any(n => t.FullName.StartsWith(n)) &&
                    !t.IsAbstract &&
                    !t.ContainsGenericParameters);

            var commands = new List<ICommand>();
            foreach (var type in types)
            {
                if (Activator.CreateInstance(type) is ICommand instance)
                {
                    commands.Add(instance);
                }
            }

            return commands;
        }
    }
}
