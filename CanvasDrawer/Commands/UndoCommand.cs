namespace CanvasDrawer.Commands
{
    public class UndoCommand : Command
    {
        public const char UndoDirective = 'U';

        public UndoCommand(string command) : base(command)
        {
            if (command.Length == 1 && command.First() != UndoDirective)
            {
                throw new InvalidProgramException();
            }
        }
    }
}
