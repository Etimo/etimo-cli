using System;

namespace Etimo.Cli
{
    public class CommandDescriptionAttribute : Attribute
    {
        public string Description { get; }

        public CommandDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
