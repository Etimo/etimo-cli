using Etimo.Cli.Abstractions;
using System.Reflection;

namespace Etimo.Cli
{
    public class OutputFormatter : IOutputFormatter
    {
        private ILogger _logger = new InformationLogger(new ConsoleOutput());

        public void UseLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Output(ICommand command)
        {
            _logger.Information(command.Message);
        }

        public void Help()
        {
            _logger.Information("Display full help screen");
        }

        public virtual void Help(ICommand command)
        {
            var helpAttributes = command.GetType().GetCustomAttributes<OptionHelpAttribute>(true);
            foreach (var attr in helpAttributes)
            {
                var optionName = attr.OptionType.GetCustomAttribute<OptionNameAttribute>()?.Name ?? string.Empty;
                var optionShortName = attr.OptionType.GetCustomAttribute<OptionShortNameAttribute>()?.ShortName ?? string.Empty;

                _logger.Information($"-{optionShortName.PadRight(5)} --{optionName.PadRight(15)} {attr.Description}");
            }
        }

        public void Error(string errorMessage)
        {
            _logger.Error(errorMessage);
        }
    }
}
