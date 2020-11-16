using System;
using Etimo.Cli.Abstractions;
using Etimo.Cli.Options;
using System.Collections.Generic;
using System.Linq;
using Etimo.Cli.Commands;

namespace Etimo.Cli
{
    public class Processor
    {
        private readonly IArgumentParser _parser;
        private readonly IOutputFormatter _formatter;
        private readonly IOutput _output;

        private IExecutionContext _context;

        public Processor(
            IArgumentParser parser,
            IOutputFormatter formatter,
            IOutput output)
        {
            _parser = parser;
            _formatter = formatter;
            _output = output;
        }

        public void Process(List<string> args)
        {
#if DEBUG
            args.Add($"--{new InteractiveOption().Name}");
#endif

            _context = Parse(args);
            if (_context.HasOption<InteractiveOption>())
            {
                while (true)
                {
                    Process();
                    Console.Write("etimo $ ");
                    args = Console.ReadLine()?.Split(' ').ToList();
                    _context = Parse(args);
                }
            }

            Process();
        }

        private IExecutionContext Parse(List<string> args)
        {
            try
            {
                return _parser.Parse(args).GetContext();
            }
            catch (ArgumentException e)
            {
                _formatter.Error(e.Message);
                return null;
            }
        }

        private void Process()
        {
            if (_context == null || _context.Command is NoCommand)
            {
                return;
            }

            _context.PrepareOptions();
            _context.Formatter = _formatter;
            _context.Output = _output;
            _context.Reflector = _parser.CommandReflector;
            RunCommand(_context.Command);
        }

        private static void RunCommand(ICommand command)
        {
            command.Prepare();

            if (command.Context.HasOption<HelpOption>())
            {
                command.Help();
                return;
            }

            command.Execute();
            command.Output();
        }
    }
}
