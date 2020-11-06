using Etimo.Cli.Abstractions;
using System.Reflection;

namespace Etimo.Cli.Options
{
    public abstract class Option : IOption
    {
        public string Name => GetType().GetCustomAttribute<OptionNameAttribute>()?.Name;
        public string ShortName => GetType().GetCustomAttribute<OptionShortNameAttribute>()?.ShortName;
        public string Description => GetType().GetCustomAttribute<OptionDescriptionAttribute>()?.Description;
        public IExecutionContext Context { get; set; }
        public virtual string Value { get; set; }

        public virtual void Prepare() { }
    }
}
