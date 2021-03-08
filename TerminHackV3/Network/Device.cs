using System;
using System.Collections.Generic;

namespace TerminHackV3.Network
{
    public class Device
    {
        public string IpAddress { get; set; } = string.Empty;

        public IEnumerable<Executable> Execuatbles { get; set; } = Array.Empty<Executable>();
    }
}
