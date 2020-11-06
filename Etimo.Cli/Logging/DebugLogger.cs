using Etimo.Cli.Abstractions;

namespace Etimo.Cli
{
    public class DebugLogger : Logger
    {
        private readonly IOutput _output;

        public DebugLogger(IOutput output)
        {
            _output = output;
        }

        public override void Debug(string message)
        {
            _output.Output(message);
        }

        public override void Information(string message)
        {
            _output.Output(message);
        }

        public override void Error(string message)
        {
            _output.Output(message);
        }
    }
}
