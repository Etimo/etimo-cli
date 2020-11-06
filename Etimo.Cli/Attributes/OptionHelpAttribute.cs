using System;

namespace Etimo.Cli
{
    public class OptionHelpAttribute : Attribute
    {
        public Type OptionType { get; }
        public string Description { get; }

        public OptionHelpAttribute(Type optionType, string description)
        {
            OptionType = optionType;
            Description = description;
        }
    }
}
