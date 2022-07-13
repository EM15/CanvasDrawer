using CanvasDrawer.Commands;

namespace CanvasDrawer.Creators
{
    public class CommandCreator : ICommandCreator
    {
        public CommandCreator()
        {
        }

        // TODO: Create and invalidCommandException¿?
        public Command CreateCommand(string commandInputText)
        {
            Command command;
            var commandDirective = commandInputText.FirstOrDefault();
            switch (commandDirective)
            {
                case 'L':
                    command = new LineCommand(commandInputText);
                    break;
                case 'R':
                    command = new RectangleCommand(commandInputText);
                    break;
                case 'B':
                    command = new BucketFillCommand(commandInputText);
                    break;
                default: // Is Canvas
                    command = new CanvasCommand(commandInputText);
                    break;
            }

            return command;
        }
    }
}
