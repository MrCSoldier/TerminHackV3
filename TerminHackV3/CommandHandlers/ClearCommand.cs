using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminHackV3.CommandHandlers
{
    class ClearCommand : ICommandHandler
    {
        public bool AppliesTo(string command)
        {
            
            return command == "clear";
        }

        public void Handle(string[] arguments, MainTerminal terminal)
        {
            terminal.Clear();

        }
    }
}