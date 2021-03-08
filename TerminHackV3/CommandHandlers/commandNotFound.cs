using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminHackV3.CommandHandlers
{
    class commandNotFound
    {
        public string[] arguments = new string[1];
        public MainTerminal terminal = new MainTerminal();

        public void Handle(string[] arguments, MainTerminal terminal)
        {

        }
    }
}
