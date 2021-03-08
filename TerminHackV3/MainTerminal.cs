using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TerminHackV3
{
    public partial class MainTerminal : Form
    {

        public static bool DeveloperMode = true;
        //public static bool firsTermin = Program.FirstTerminal;
        readonly private StringBuilder _outputBuffer = new StringBuilder();
        public string[] command = new string[1];
        protected private const int WM_NCLBUTTONDOWN = 0x00A1;
        protected private const int HT_CAPTION = 0x2;
        [DllImport("user32", CharSet = CharSet.Auto)]
        protected private static extern bool ReleaseCapture();
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        //MainTerminal f = new MainTerminal();
        //readonly MainTerminal mTerminal = new MainTerminal();

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Rectangle rct = DisplayRectangle;
                if (rct.Contains(e.Location))
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        public void WriteToBuffer(string message)
        {
            _outputBuffer.AppendLine(message);
        }

        public void FlushBuffer()
        {
            outputBufferCtrl.Text = _outputBuffer.ToString();
        }
		
		public void Clear()
		{
			outputBufferCtrl.Text = "";
		}
		
        public void ChangeTextColour(string TextColour)
        {
            switch (TextColour)
            {
                case "red":
                    outputBufferCtrl.ForeColor = Color.Red;
                    break;
                case "yellow":
                    outputBufferCtrl.ForeColor = Color.Yellow;
                    break;
                case "green":
                    outputBufferCtrl.ForeColor = Color.Green;
                    break;
                default:
                    outputBufferCtrl.ForeColor = Color.White;
                    break;
            }
        }

        public MainTerminal()
        {
            InitializeComponent();
        }

        public void Submit(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                Console.WriteLine("Enter key ress detected!");
                //MessageBox.Show("I see you pressed Enter."); // <--- This is a Test MessageBox. This is to show that the function is ran.
                string[] input = ConsoleInput.Text.ToLower().Split(' '); //.ToLower()

                var command = input[0].ToLower();
                var arguments = input.Length > 1 ? input[1..^0] : Array.Empty<string>();
                CommandHandler.HandleCommand(command, arguments, this);
                ConsoleInput.Text = "";
            }
        }

        private void ConsoleInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainTerminal_Load(object sender, EventArgs e)
        {
        }

        private void outputBufferCtrl_Click(object sender, EventArgs e)
        {

        }
    }

    /*
    public static class Variables
    {
        public static string[] TerminInput = {};
    }
    */

}