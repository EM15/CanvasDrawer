using CanvasDrawer.Commands;
using CanvasDrawer.Exceptions;

namespace CanvasDrawer.Creators
{
    public class CommandCreator : ICommandCreator
    {
        public CommandCreator()
        {
        }

        public Command CreateCommand(string commandInputText)
        {
            commandInputText = commandInputText ?? string.Empty; // To avoid null check below

            Command command;
            char commandDirective = commandInputText.FirstOrDefault();
            switch (commandDirective)
            {
                case LineCommand.CommandDirective:
                    command = new LineCommand(commandInputText);
                    break;
                case RectangleCommand.CommandDirective:
                    command = new RectangleCommand(commandInputText);
                    break;
                case BucketFillCommand.CommandDirective:
                    command = new BucketFillCommand(commandInputText);
                    break;
                case CanvasCommand.CommandDirective:
                    command = new CanvasCommand(commandInputText);
                    break;
                default:
                    throw new InvalidCommandException();
            }

            return command;
        }
    }
}
