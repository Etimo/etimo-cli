using Etimo.Cli.Commands;
using Etimo.Cli.Options;

namespace Etimo.Cli.Tool.Tests.Commands
{
    [CommandName("test new")]
    [CommandFamily("test")]
    [CommandDescription("Another simple test command")]
    [OptionHelp(typeof(HelpOption), "Displays this help text")]
    internal class NewTestCommand : Command
    {
        public override void Execute()
        {
            Message = "NewTest command executed";
        }
    }
}
