using CanvasDrawer.Exceptions;

namespace CanvasDrawer.Commands
{
    public abstract class Command
    {
        public string CommandText { get; private set; }

        public Command(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new InvalidCommandException();
            }

            CommandText = command;
        }
    }
}
