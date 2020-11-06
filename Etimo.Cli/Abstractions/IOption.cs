namespace Etimo.Cli.Abstractions
{
    public interface IOption
    {
        string Name { get; }
        string ShortName { get; }
        string Description { get; }
        string Value { get; set; }

        /// <summary>
        /// The Prepare() function is run before any commands are executed.
        /// </summary>
        void Prepare();
    }
}
