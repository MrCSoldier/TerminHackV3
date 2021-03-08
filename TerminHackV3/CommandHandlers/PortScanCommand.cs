using System;
using System.Linq;
using TerminHackV3.Network;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TerminHackV3.CommandHandlers
{
    public class PortScanCommand : ICommandHandler
    {
        
        public static IEnumerable<Device> Devices { get; set; } = Array.Empty<Device>();
        public string[] arguments = new string[5];
        public MainTerminal terminal = new MainTerminal();
        public bool AppliesTo(string command)
        {
            return command == "portscan";
        }

        private const string _commandSyntax = "portscan <ip> <from> <to>";

        public void Handle(string[] arguments, MainTerminal terminal)
        {

            if (arguments.Length < 3)
            {
                terminal.WriteToBuffer($"Invalid syntax: {_commandSyntax}");
                terminal.FlushBuffer();
                return;
            }

            if (!int.TryParse(arguments[1], out var portFrom))
            {
                terminal.WriteToBuffer($"Invalid syntax: {_commandSyntax}");
                terminal.FlushBuffer();
                return;
            }

            if (!int.TryParse(arguments[2], out var portTo))
            {
                terminal.WriteToBuffer($"Invalid syntax: {_commandSyntax}");
                terminal.FlushBuffer();
                return;
            }
            
            var gateway = NetworkHandler.GetGateway(arguments[0]);

            if (gateway == null)
            {
                terminal.WriteToBuffer("Invalid syntax: connect <ip address>");
                terminal.FlushBuffer();
                return;
            }

            var openPorts = gateway.Devices.Where(x => x.Execuatbles.Any(exe => portFrom <= exe.NetworkInterfacePort && portTo >= exe.NetworkInterfacePort)).SelectMany(x => x.Execuatbles.Select(exe => exe.NetworkInterfacePort)).ToArray();
            /*var device = Devices;*/
            /*if (!int.TryParse(arguments[1], out portFrom))
            {
                if (!int.TryParse(arguments[2], out portTo)) {
                    for (var i = 0; i <= 65535; i++)
                    {
                        var portState = openPorts.Contains(i) ? "OPEN" : "CLOSED"; //short if staement. if(openports.Contains(i)) { portstate = "OPEN" } else { pertstate = "CLSOED" } 
                        terminal.WriteToBuffer($"Port {i} - {portState}");  //Sends Output as $"Port {i} - {portState}"
                    } 
                }
            }*/
            
            //openPorts = gateway.Devices.Where(x => x.Execuatbles.Any(exe => portFrom <= exe.NetworkInterfacePort && portTo >= exe.NetworkInterfacePort)).SelectMany(x => x.Execuatbles.Select(exe => exe.NetworkInterfacePort)).ToArray();
            for (var i = portFrom; i <= portTo; i++)
            {
                var portState = openPorts.Contains(i) ? "OPEN" : "CLOSED"; //short if staement. if(openports.Contains(i)) { portstate = "OPEN" } else { pertstate = "CLSOED" } 
                terminal.WriteToBuffer($"Port {i} - {portState}");  //Sends Output as $"Port {i} - {portState}"
            }

            

            terminal.FlushBuffer();
        }
    }
}
