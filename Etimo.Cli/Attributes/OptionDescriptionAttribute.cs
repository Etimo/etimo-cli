using System;

namespace Etimo.Cli
{
    public class OptionDescriptionAttribute : Attribute
    {
        public string Description { get; }

        public OptionDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
