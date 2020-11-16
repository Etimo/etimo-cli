namespace Etimo.Cli.Tests.Factories
{
    internal class ArgumentParserFactory
    {
        public static ArgumentParser CreateArgumentParser()
        {
            var commandReflector = CommandReflectorFactory.CreateCommandReflector("Etimo.Cli.Tests.Commands");
            var optionReflector = OptionReflectorFactory.CreateOptionReflector("Etimo.Cli.Tests.Options");
            return new ArgumentParser(commandReflector, optionReflector);
        }
    }
}
