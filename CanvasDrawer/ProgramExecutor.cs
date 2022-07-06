using CanvasDrawer.Drawings;
using System.Drawing;

namespace CanvasDrawer
{
    internal class ProgramExecutor
    {
        private readonly ICommandValidator commandValidator;
        private readonly IDrawer drawer;
        private Canvas? canvas;

        public ProgramExecutor(ICommandValidator commandValidator, IDrawer drawer)
        {
            this.commandValidator = commandValidator;
            this.drawer = drawer;
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

                canvas = new Canvas(command!);
                drawer.Draw(canvas);
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
