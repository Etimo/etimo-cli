namespace Etimo.Cli.Abstractions
{
    public interface ILogger
    {
        void Debug(string message);
        void Information(string message);
        void Error(string message);
    }
}
