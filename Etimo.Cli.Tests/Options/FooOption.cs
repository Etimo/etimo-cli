using Etimo.Cli.Options;
using System;

namespace Etimo.Cli.Tool.Tests.Options
{
    [OptionName("foo")]
    [OptionShortName('f')]
    [OptionDescription("Foo option")]
    public class FooOption : Option
    {
        public override void Prepare()
        {
            Console.WriteLine("Preparing FooOption");
        }
    }
}
