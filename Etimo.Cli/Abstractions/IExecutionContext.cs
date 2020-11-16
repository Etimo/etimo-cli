using System.Collections.Generic;

namespace Etimo.Cli.Abstractions
{
    public interface IExecutionContext
    {
        ICommand Command { get; }
        List<IOption> Options { get; }
        List<string> Arguments { get; }
        List<string> ProgramArguments { get; }
        IDictionary<string, object> Properties { get; }
        ILogger Logger { get; set; }
        IOutputFormatter Formatter { get; set; }
        IOutput Output { get; set; }
        ICommandReflector Reflector { get; set; }
        IExecutionContext PrepareOptions();
        bool HasOption<T>() where T : IOption;
        T GetProperty<T>(string name) where T : class;
        object GetProperty(string name);
    }
}
