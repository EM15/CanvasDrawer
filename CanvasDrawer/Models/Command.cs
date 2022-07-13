namespace CanvasDrawer.Models
{
    public abstract class Command
    {
        public string CommandText { get; private set; }

        public Command(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                ThrowInvalidCommandException();
            }

            CommandText = command;
        }

        protected void ThrowInvalidCommandException() => throw new ArgumentException("Invalid command");
    }
}
