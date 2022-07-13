namespace CanvasDrawer.Models
{
    public abstract class Command
    {
        public string CommandText { get; private set; }

        public Command(string command)
        {
            CommandText = command;
        }
    }
}
