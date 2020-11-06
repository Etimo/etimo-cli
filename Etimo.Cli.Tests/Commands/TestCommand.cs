using Etimo.Cli.Commands;

namespace Etimo.Cli.Tool.Tests.Commands
{
    [CommandName("test")]
    [CommandFamily("test")]
    [CommandDescription("A simple test command")]
    internal class TestCommand : Command
    {
        public override void Execute()
        {
            Message = "Test command executed";
        }
    }
}
