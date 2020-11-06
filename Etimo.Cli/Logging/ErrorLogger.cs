using Etimo.Cli.Abstractions;

namespace Etimo.Cli
{
    public class ErrorLogger : Logger
    {
        private readonly IOutput _output;

        public ErrorLogger(IOutput output)
        {
            _output = output;
        }

        public override void Error(string message)
        {
            _output.Output(message);
        }
    }
}
