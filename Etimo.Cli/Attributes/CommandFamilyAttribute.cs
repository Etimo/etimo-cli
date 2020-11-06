using System;

namespace Etimo.Cli
{
    public class CommandFamilyAttribute : Attribute
    {
        public string Family { get; }

        public CommandFamilyAttribute(string family)
        {
            Family = family;
        }
    }
}
