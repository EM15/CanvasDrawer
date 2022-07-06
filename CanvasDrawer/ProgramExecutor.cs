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
            Console.WriteLine("Create a new Canvas with the following command: C w h");
            while (canvas is null)
            {
                var command = Console.ReadLine();
                if (commandValidator.IsCanvasCommandValid(command))
                {
                    // TODO: Extract width, height
                    canvas = new Rectangle();
                }
            }
        }

        public void ReadCommand()
        {
            throw new NotImplementedException();
        }
    }
}
