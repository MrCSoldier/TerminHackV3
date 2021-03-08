using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TerminHackV3.Network
{
    public static class NetworkHandler
    {
        private static IEnumerable<Gateway> _gateways = Array.Empty<Gateway>();

        public static async Task LoadNetworksAsync()
        {
            var source = await System.IO.File.ReadAllTextAsync($"{AppDomain.CurrentDomain.BaseDirectory}/Network/Config/Gateways.json");
            _gateways = JsonSerializer.Deserialize<IEnumerable<Gateway>>(source);
        }

        public static Gateway GetGateway(string Ipv4Address)
        {
            return _gateways.SingleOrDefault(x => x.Ipv4Address == Ipv4Address);
        }
    }
}
