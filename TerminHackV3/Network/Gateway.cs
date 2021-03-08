using System;
using System.Collections.Generic;

namespace TerminHackV3.Network
{
    public class Gateway
    {
        public string Ipv4Address { get; set; } = string.Empty;

        public IEnumerable<Device> Devices { get; set; } = Array.Empty<Device>();
    }
}
