using System;

namespace Etimo.Cli
{
    public class OptionShortNameAttribute : Attribute
    {
        public string ShortName { get; }

        public OptionShortNameAttribute(char shortName)
        {
            ShortName = shortName.ToString().ToLowerInvariant();
        }
    }
}
