namespace Etimo.Cli.Commands
{
    /// <summary>
    /// Exits the application.
    /// </summary>
    [CommandName("exit")]
    [CommandDescription("Exits the application.")]
    public class ExitCommand : Command
    {
        public override void Execute()
        {
            System.Environment.Exit(0);
        }
    }
}
