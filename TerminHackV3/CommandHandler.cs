using System.Collections.Generic;
using System.Linq;
using TerminHackV3.CommandHandlers;
using System.Text;


namespace TerminHackV3
{
    public static class CommandHandler
    {
        public static List<string> ValidCommand = new List<string> { "new", "connect", "portscan", "exit", "show", "clear", "echo", "music" };

        private static readonly IEnumerable<ICommandHandler> _commandHandlers = new ICommandHandler[] {
            new NewApplicationCommand(),
            new ConnectCommand(),
            new PortScanCommand(),
            new ArgumentCommand(),
            new ExitCommand(),
            new ClearCommand(),
            new EchoCommand(),
            new MusicCommand()
        };

        public static void HandleCommand(string command, string[] arguments, MainTerminal terminal)
        {
            command.ToLower();
            if (ValidCommand.Contains(command))
            {
                var handler = _commandHandlers.Single(x => x.AppliesTo(command));
                handler.Handle(arguments, terminal);
            }
            else
            {
                terminal.ChangeTextColour("red");
                terminal.WriteToBuffer("Unknown Command: " + command);
                terminal.FlushBuffer();
            }
        }
    }

}