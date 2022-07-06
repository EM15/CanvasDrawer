using System.Drawing;

namespace CanvasDrawer
{
    internal class ProgramExecutor
    {
        private readonly ICommandValidator commandValidator;
        private Rectangle? canvas;

        public ProgramExecutor(ICommandValidator commandValidator)
        {
            this.commandValidator = commandValidator;
        }

        public void ReadCanvas()
        {
            Console.WriteLine("Create a new Canvas with the following command: \"C w h\" where 'w' is width and 'h' is height");
            while (canvas is null)
            {
                var command = Console.ReadLine();
                var isValid = commandValidator.IsCanvasCommandValid(command);
                if (!isValid)
                {
                    Console.WriteLine("Incorrect command");
                    continue;
                }

                // TODO: Extract width, height
                canvas = new Rectangle();
            }
        }

        public void ReadCommand()
        {
            var command = Console.ReadLine();
            while(command != "Q")
            {
                var isValid = commandValidator.IsDrawingCommandValid(command);
                if (!isValid)
                {
                    Console.WriteLine("Incorrect command");
                    command = Console.ReadLine();
                    continue;
                }

                command = Console.ReadLine();
            }
        }
    }
}
