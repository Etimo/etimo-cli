using System;

namespace Etimo.Cli
{
    public class CommandNameAttribute : Attribute
    {
        public string Name { get; }

        public CommandNameAttribute(string name)
        {
            Name = name;
        }
    }
}
