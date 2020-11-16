using System.Collections.Generic;
using System.Linq;
using Etimo.Cli.Abstractions;
using System.Reflection;
using Etimo.Cli.Options;

namespace Etimo.Cli.Commands
{
    [OptionHelp(typeof(HelpOption), "Displays this help text")]
    public abstract class Command : ICommand
    {
        public string Name => GetType().GetCustomAttribute<CommandNameAttribute>()?.Name;
        public string Family => GetType().GetCustomAttribute<CommandFamilyAttribute>()?.Family;
        public string Description => GetType().GetCustomAttribute<CommandDescriptionAttribute>()?.Description;
        protected ILogger Logger => Context.Logger;
        public string Message { get; protected set; }
        public virtual IExecutionContext Context { get; set; } = new ExecutionContext();

        public void Output() => Context.Formatter.Output(this);
        public virtual void Help() => Context.Formatter.Help(this);
        public virtual void Prepare() { }

        public List<ICommand> GetFamilyMembers()
        {
            if (Family == null)
            {
                return new List<ICommand>();
            }

            var commands = Context.Reflector.GetCommands();
            return commands.Where(c => c.Family == Family).ToList();
        }

        public abstract void Execute();
    }
}
