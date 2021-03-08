using System;

namespace TerminHackV3.CommandHandlers
{
    public class ArgumentCommand : ICommandHandler
    {
        public bool AppliesTo(string command)
        {
            return command == "flood";
        }

        public void Handle(string[] arguments, MainTerminal terminal)
        {
            if (MainTerminal.DeveloperMode == true)
            {
                for (int i = 0; i < 40;) 
                { 
                    terminal.WriteToBuffer("connect 192.168.1.6");
                    terminal.FlushBuffer();
                    
                }
                return;
            }
            else
            {
                return;
            }
        }

    }
}
