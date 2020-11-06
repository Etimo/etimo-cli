namespace Etimo.Cli.Options
{
    [OptionName("debug")]
    [OptionDescription("Prints debug messages.")]
    public class DebugOption : Option
    {
        public override void Prepare()
        {
            Context.Logger = new DebugLogger(new ConsoleOutput());
        }
    }
}
