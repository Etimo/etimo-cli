using System.Collections.Generic;

namespace Etimo.Cli.Abstractions
{
    public interface IOptionReflector
    {
        IEnumerable<IOption> GetOptions();
    }
}
