namespace Etimo.Cli.Commands
{
    /// <summary>
    /// No command was given when running the program.
    /// </summary>
    public class NoCommand : Command
    {
        public override void Execute()
        {
            Message = "No command given";
        }
    }
}
