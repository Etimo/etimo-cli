using System.Reflection;

namespace Etimo.Cli.Commands
{
    [CommandName("version")]
    [CommandFamily("version")]
    [CommandDescription("Displays the current version of etimo-cli.")]
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
