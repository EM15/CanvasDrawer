using CanvasDrawer.Models;
using CanvasDrawer.Validators;

namespace CanvasDrawer.Creators
{
    public class CommandCreator : ICommandCreator
    {
        private readonly ICommandValidator commandValidator;

        public CommandCreator(ICommandValidator commandValidator)
        {
            this.commandValidator = commandValidator;
        }

        public Command CreateCommand(string? commandInputText)
        {
            var isValid = commandValidator.IsCommandValid(commandInputText);
            if (!isValid)
            {
                throw new ArgumentException("Invalid command");
            }

            Command command;
            var commandDirective = commandInputText!.First();
            switch (commandDirective)
            {
                case 'L':
                    command = new Line(commandInputText!);
                    break;
                case 'R':
                    command = new Rectangle(commandInputText!);
                    break;
                case 'B':
                    command = new Line(commandInputText!);
                    break;
                default: // Is Canvas
                    command = new Canvas(commandInputText!);
                    break;
            }

            return command;
        }
    }
}
