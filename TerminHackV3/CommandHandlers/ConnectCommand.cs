using System.Collections.Generic;
using TerminHackV3.Network;
using System.Threading;
using System.Threading.Tasks;

namespace TerminHackV3.CommandHandlers
{
    public class ConnectCommand : ICommandHandler
    {

        public bool AppliesTo(string command)
        {
            command.ToLower();
            return command == "connect";
        }

        public float DelayCommand(float slowdownProcessingSpeed)
        {

            return slowdownProcessingSpeed;
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
                terminal.WriteToBuffer("Connecting to IP Address  " + arguments[0] + "..>");
                terminal.FlushBuffer();
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
