/*using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TerminHackV3
{
    public partial class otherTerminal : Form
    {
        private StringBuilder _outputBuffer = new StringBuilder();
        public string[] command = new string[0];
        protected private const int WM_NCLBUTTONDOWN = 0x00A1;
        protected private const int HT_CAPTION = 0x2;
        [DllImport("user32", CharSet = CharSet.Auto)]
        protected private static extern bool ReleaseCapture();
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Rectangle rct = DisplayRectangle;
                if (rct.Contains(e.Location))
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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
                    //If you want to do line highlighting then you probably want to use a custom control rather than a label.
                    //Take a look into it later
            }
        }

        public otherTerminal()
        {
            InitializeComponent();
        }

        private void Submit(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                otherTerminal otermin = new otherTerminal();
                Console.WriteLine("Enter key ress detected!");
                //MessageBox.Show("I see you pressed Enter."); // <--- This is a Test MessageBox. This is to show that the function is ran.
                string[] input = ConsoleInput.Text.ToLower().Split(' '); //.ToLower()
                var command = input[0];
                var arguments = input.Length > 1 ? input[1..^0] : Array.Empty<string>();
                //CommandHandler.HandleCommand(command, arguments);
                ConsoleInput.Text = "";
            }
        }

        private void ConsoleInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void outputBufferCtrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void outputBufferCtrl_Click(object sender, EventArgs e)
        {

        }

        private void outputBufferCtrl_Click_1(object sender, EventArgs e)
        {

        }

        private void otherTerminal_Load(object sender, EventArgs e)
        {

        }
    }

    
    public static class Variables
    {
        public static string[] TerminInput = {};
    }
    

}*/