using Etimo.Cli.Commands;

namespace Etimo.Cli.Tests.Commands
{
    [CommandName("test2")]
    internal class TestWithoutFamilyCommand : Command
    {
        public override void Execute()
        {
            Message = "TestWithoutFamily command executed";
        }
    }
}
