using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TerminHackV3
{
    public partial class MainTerminal : Form
    {
        //public object commandNotFound { get; set; }
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
            MoveTextUp();
            outputBufferCtrl.Text = _outputBuffer.ToString();
        }
        public void MoveTextUp() {
            TerminalOutputLabel1.Text = TerminalOutputLabel2.Text;
            TerminalOutputLabel2.Text = TerminalOutputLabel3.Text;
            TerminalOutputLabel3.Text = TerminalOutputLabel4.Text;
            TerminalOutputLabel4.Text = TerminalOutputLabel5.Text;
            TerminalOutputLabel5.Text = TerminalOutputLabel6.Text;
            TerminalOutputLabel6.Text = TerminalOutputLabel7.Text;
            TerminalOutputLabel7.Text = TerminalOutputLabel8.Text;
            TerminalOutputLabel8.Text = TerminalOutputLabel9.Text;
            TerminalOutputLabel9.Text = TerminalOutputLabel10.Text;
            TerminalOutputLabel10.Text = TerminalOutputLabel11.Text;
            TerminalOutputLabel11.Text = TerminalOutputLabel12.Text;
            TerminalOutputLabel12.Text = TerminalOutputLabel13.Text;
            TerminalOutputLabel13.Text = TerminalOutputLabel14.Text;
            TerminalOutputLabel14.Text = TerminalOutputLabel15.Text;
            TerminalOutputLabel15.Text = TerminalOutputLabel16.Text;
            TerminalOutputLabel16.Text = TerminalOutputLabel17.Text;
            TerminalOutputLabel17.Text = TerminalOutputLabel18.Text;
            TerminalOutputLabel18.Text = TerminalOutputLabel19.Text;
            TerminalOutputLabel19.Text = TerminalOutputLabel20.Text;
            TerminalOutputLabel20.Text = TerminalOutputLabel21.Text;
            TerminalOutputLabel21.Text = TerminalOutputLabel22.Text;
            TerminalOutputLabel22.Text = TerminalOutputLabel23.Text;
            TerminalOutputLabel23.Text = TerminalOutputLabel24.Text;
            TerminalOutputLabel24.Text = TerminalOutputLabel25.Text;
            TerminalOutputLabel25.Text = TerminalOutputLabel26.Text;
            TerminalOutputLabel26.Text = TerminalOutputLabel27.Text;
            TerminalOutputLabel27.Text = TerminalOutputLabel28.Text;
            TerminalOutputLabel28.Text = TerminalOutputLabel29.Text;
            TerminalOutputLabel29.Text = TerminalOutputLabel30.Text;
            TerminalOutputLabel30.Text = outputBufferCtrl.Text;
            outputBufferCtrl.Text = ConsoleInput.Text;
            outputBufferCtrl.Text = "";
        }
            



		public void Clear()
		{
			outputBufferCtrl.Text = "";
            TerminalOutputLabel1.Text = "";
            TerminalOutputLabel2.Text = "";
            TerminalOutputLabel3.Text = "";
            TerminalOutputLabel4.Text = "";
            TerminalOutputLabel5.Text = "";
            TerminalOutputLabel6.Text = "";
            TerminalOutputLabel7.Text = "";
            TerminalOutputLabel8.Text = "";
            TerminalOutputLabel9.Text = "";
            TerminalOutputLabel10.Text = "";
            TerminalOutputLabel11.Text = "";
            TerminalOutputLabel12.Text = "";
            TerminalOutputLabel13.Text = "";
            TerminalOutputLabel14.Text = "";
            TerminalOutputLabel15.Text = "";
            TerminalOutputLabel16.Text = "";
            TerminalOutputLabel17.Text = "";
            TerminalOutputLabel18.Text = "";
            TerminalOutputLabel19.Text = "";
            TerminalOutputLabel20.Text = "";
            TerminalOutputLabel21.Text = "";
            TerminalOutputLabel22.Text = "";
            TerminalOutputLabel23.Text = "";
            TerminalOutputLabel24.Text = "";
            TerminalOutputLabel25.Text = "";
            TerminalOutputLabel26.Text = "";
            TerminalOutputLabel27.Text = "";
            TerminalOutputLabel28.Text = "";
            TerminalOutputLabel29.Text = "";
            TerminalOutputLabel30.Text = "";
        }
		
        public void ChangeTextColour(string TextColour)
        {
            outputBufferCtrl.ForeColor = TextColour switch
            {
                "red" => Color.Red,
                "yellow" => Color.Yellow,
                "green" => Color.Green,
                _ => Color.White,
            };
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

        private void MainTerminal_Load(object sender, EventArgs e)
        {   
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.Combine(Directory.GetCurrentDirectory() + "\\..\\..\\..\\Audio\\AI\\", "welcome.wav"));
            player.Play();
        }
    }

}