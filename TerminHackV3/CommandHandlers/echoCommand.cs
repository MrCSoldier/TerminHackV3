namespace TerminHackV3.CommandHandlers
{
    public class EchoCommand : ICommandHandler
    {
        public string[] arguments = new string[0];
        public MainTerminal terminal = new MainTerminal();
        public bool AppliesTo(string command)
        {
            command.ToLower();
            return command == "echo";
        }

        public void Handle(string[] arguments, MainTerminal terminal)
        {
            string args = arguments[1..^0].ToString();
            //string args = arguments.ToString();
            terminal.WriteToBuffer(args);
        }

    }
}
