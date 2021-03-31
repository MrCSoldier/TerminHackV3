namespace TerminHackV3.CommandHandlers
{
    public class NewApplicationCommand : ICommandHandler
    {

        public string[] arguments = new string[1];
        public MainTerminal terminal = new MainTerminal();
        public bool AppliesTo(string command)
        {
            return command == "new";
        }

        public float DelayCommand(float slowdownProcessingSpeed)
        {
            return slowdownProcessingSpeed;
        }

        public void Handle(string[] arguments, MainTerminal terminal)
        {
            switch (arguments[0])
            {
                case "terminal":
                    new MainTerminal().Show();
                    terminal.WriteToBuffer("Successfully Openned a new Terminal");
                    terminal.FlushBuffer();
                    //Close();

                    break;
                case "irc":
                    terminal.ChangeTextColour("yelow");
                    terminal.WriteToBuffer("Error: IRChat is under development!");
                    break;
                case "IRChat":
                    terminal.ChangeTextColour("yelow");
                    terminal.WriteToBuffer("Error: IRChat is under development!");
                    break;
                default:
                    terminal.ChangeTextColour("red");
                    terminal.WriteToBuffer("Invalid Syntax: new <application>");
                    return;
            }
        }
    }
}
