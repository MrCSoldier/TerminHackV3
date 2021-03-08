using System.Collections.Generic;
using System.Linq;
using TerminHackV3.CommandHandlers;

namespace TerminHackV3
{
    public static class CommandHandler
    {

        public static List<string> ValidCommand = new List<string> { "new", "connect", "portscan", "exit", "show" };

        private static readonly IEnumerable<ICommandHandler> _commandHandlers = new ICommandHandler[] {
            new NewApplicationCommand(),
            new ConnectCommand(),
            new PortScanCommand(),
            new ArgumentCommand(),
            new ExitCommand(),
            new ClearCommand()
        };

        public static void HandleCommand(string command, string[] arguments, MainTerminal terminal)
        {

            var handler = _commandHandlers.Single(x => x.AppliesTo(command));
            handler.Handle(arguments, terminal);
            
            
            /*var handlerCount = handler.;
            if (handlerCount > 1)
            {
                throw new InvalidOperationException($"There were multiple handlers registered to the command.");
            }
            if (handlerCount < 1)
            {
                throw new InvalidOperationException($"There were no handlers registered to the command.");
                //terminal.WriteToBuffer(command + " is not a valid command");
            }*/
        }
    }
}