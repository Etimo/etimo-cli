using System.Reflection;

namespace Etimo.Cli.Commands
{
    /// <summary>
    /// Displays the current version of the command-line interface.
    /// </summary>
    [CommandName("version")]
    [CommandDescription("Displays the current version of the command-line interface.")]
    public class VersionCommand : Command
    {
        public override void Execute()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "0.0.0";

            Message = $"etimo-cli v{version}";
        }
    }
}
