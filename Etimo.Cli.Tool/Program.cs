using System.Linq;

namespace Etimo.Cli.Tool
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var commandReflector = CommandReflectorFactory.CreateCommandReflector("Etimo.Cli.Commands", "Etimo.Cli.Tool.Commands");
            var optionReflector =  OptionReflectorFactory.CreateOptionReflector("Etimo.Cli.Options", "Etimo.Cli.Tool.Options");
            var parser = new ArgumentParser(commandReflector, optionReflector);
            var formatter = new OutputFormatter();
            var output = new ConsoleOutput();
            var processor = new Processor(parser, formatter, output);
            var arguments = args.ToList();

            processor.Process(arguments);
        }
    }
}
