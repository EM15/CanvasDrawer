using CanvasDrawer.Models;

namespace CanvasDrawer.Creators
{
    public class CommandCreator : ICommandCreator
    {
        public CommandCreator()
        {
        }

        public Command CreateCommand(string commandInputText)
        {
            Command command;
            var commandDirective = commandInputText.First();
            switch (commandDirective)
            {
                case 'L':
                    command = new Line(commandInputText);
                    break;
                case 'R':
                    command = new Rectangle(commandInputText);
                    break;
                case 'B':
                    command = new BucketFill(commandInputText);
                    break;
                default: // Is Canvas
                    command = new Canvas(commandInputText);
                    break;
            }

            return command;
        }
    }
}
