using System.Collections.Generic;
using TerminHackV3.Network;

namespace TerminHackV3.CommandHandlers
{
    public class ConnectCommand : ICommandHandler
    {
        readonly List<string> ValidIPv4Address = new List<string> { "1921.168.12.25" };

        public bool AppliesTo(string command)
        {
            return command == "connect";
        }

        public void Handle(string[] arguments, MainTerminal terminal)
        {

            if (arguments.Length < 1)
            {
                terminal.WriteToBuffer("Invalid syntax: connect <ip address>");
                terminal.FlushBuffer();
                return;
            }

            var gateway = NetworkHandler.GetGateway(arguments[0]);
            if (gateway != null)
            {

                terminal.ChangeTextColour("Green");
                terminal.WriteToBuffer("Successfully Connected to " + arguments[0]);
            }
            else
            {
                terminal.ChangeTextColour("red");
                terminal.WriteToBuffer("Connect: IPv4 address either not found or invalid");
            }

            terminal.WriteToBuffer("Under Development!");
            terminal.FlushBuffer();
        }
    }
}
