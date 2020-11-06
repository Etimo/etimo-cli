using System;

namespace Etimo.Cli
{
    public class OptionNameAttribute : Attribute
    {
        public string Name { get; }

        public OptionNameAttribute(string name)
        {
            Name = name.ToLowerInvariant();
        }
    }
}
