namespace TerminHackV3.CommandHandlers
{
    public class ExitCommand : ICommandHandler
    {
        public string[] arguments = new string[0];
        public MainTerminal terminal = new MainTerminal();
        public bool AppliesTo(string command)
        {
            return command == "exit";
        }
        public void Handle(string[] arguments, MainTerminal terminal)
        {
            //Environment.Exit(0);
            terminal.Close();
        }
    }
}


//handler.First().Handle(yourArguments,yourterminal);
