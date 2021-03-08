using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TerminHackV3.Network;

namespace TerminHackV3
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static async Task Main()
        {
            await NetworkHandler.LoadNetworksAsync();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MultiFormContext(new MainTerminal()));
        }
    }
}