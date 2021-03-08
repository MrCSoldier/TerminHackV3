namespace TerminHackV3
{
    public interface ICommandHandler
    {
        public bool AppliesTo(string command);
        public void Handle(string[] arguments, MainTerminal terminal);
    }
}
