using Etimo.Cli.Abstractions;

namespace Etimo.Cli
{
    internal class InformationLogger : Logger
    {
        private readonly IOutput _output;

        public InformationLogger(IOutput output)
        {
            _output = output;
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
