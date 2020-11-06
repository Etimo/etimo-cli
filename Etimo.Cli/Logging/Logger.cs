using Etimo.Cli.Abstractions;

namespace Etimo.Cli
{
    public class Logger : ILogger
    {
        public virtual void Debug(string message) { }
        public virtual void Information(string message) { }
        public virtual void Error(string message) { }
    }
}
