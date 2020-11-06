using Etimo.Cli.Options;

namespace Etimo.Cli.Commands
{
    [CommandName("help")]
    [CommandFamily("help")]
    [CommandDescription("Shows the help screen.")]
    public class HelpCommand : Command
    {
        public override void Prepare()
        {
            // This will trigger the Help() function in the Processor.
            Context.Options.Add(new HelpOption());
        }

        public override void Execute() { }

        public override void Help()
        {
            // Instead of showing help for just this command, show the main help screen.
            Context.Formatter.Help();
        }
    }
}
