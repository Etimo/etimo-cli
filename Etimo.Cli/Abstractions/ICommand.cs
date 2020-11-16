using System.Collections.Generic;

namespace Etimo.Cli.Abstractions
{
    public interface ICommand
    {
        string Name { get; }
        string Family { get; }
        string Description { get; }
        string Message { get; }
        IExecutionContext Context { get; set; }

        /// <summary>
        /// Prepares execution of the command.
        /// </summary>
        void Prepare();

        /// <summary>
        /// Execute command.
        /// </summary>
        void Execute();

        /// <summary>
        /// Show help for command.
        /// </summary>
        void Help();

        /// <summary>
        /// Print output for command.
        /// </summary>
        void Output();

        /// <summary>
        /// Get a list of the command's family members.
        /// </summary>
        /// <returns>List of ICommands</returns>
        List<ICommand> GetFamilyMembers();
    }
}
