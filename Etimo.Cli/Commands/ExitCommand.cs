using Etimo.Cli.Options;

namespace Etimo.Cli.Commands
{
    [CommandName("exit")]
    [CommandFamily("exit")]
    [CommandDescription("Exits the application.")]
    public class ExitCommand : Command
    {
        public override void Execute()
        {
            System.Environment.Exit(0);
        }
    }
}
