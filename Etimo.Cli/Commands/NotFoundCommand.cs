namespace Etimo.Cli.Commands
{
    /// <summary>
    /// A command was given but no matching command could be found.
    /// </summary>
    public class NotFoundCommand : Command
    {
        public override void Execute()
        {
            Message = "Command not found";
        }
    }
}
