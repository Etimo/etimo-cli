using Etimo.Cli.Abstractions;
using System;

namespace Etimo.Cli
{
    public class ConsoleOutput : IOutput
    {
        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}
