using Etimo.Cli.Abstractions;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Etimo.Cli
{
    public class ExecutionContext : IExecutionContext
    {
        public ICommand Command { get; set; }
        public List<IOption> Options { get; set; } = new List<IOption>();
        public List<string> Arguments { get; set; } = new List<string>();
        public List<string> ProgramArguments { get; set; }
        public IDictionary<string, object> Properties { get; set; } = new ConcurrentDictionary<string, object>();
        public ILogger Logger { get; set; } = new InformationLogger(new ConsoleOutput());
        public IOutputFormatter Formatter { get; set; } = new OutputFormatter();
        public IOutput Output { get; set; } = new ConsoleOutput();

        public IExecutionContext PrepareOptions()
        {
            Options.ForEach(o =>  o.Prepare());
            return this;
        }

        public bool HasOption<T>() where T : IOption
        {
            return Options.Any(o => o.GetType() == typeof(T));
        }

        public T GetProperty<T>(string name) where T : class
        {
            if (Properties.ContainsKey(name) && Properties[name] is T value)
            {
                return value;
            }

            return null;
        }

        public object GetProperty(string name) => GetProperty<object>(name);
    }
}
