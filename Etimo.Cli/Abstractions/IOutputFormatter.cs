namespace Etimo.Cli.Abstractions
{
    public interface IOutputFormatter
    {
        void UseLogger(ILogger logger);
        void Output(ICommand command);
        void Help();
        void Help(ICommand command);
        void Error(string errorMessage);
    }
}
