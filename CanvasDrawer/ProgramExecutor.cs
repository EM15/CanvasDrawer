using CanvasDrawer.Creators;
using CanvasDrawer.Drawings;
using CanvasDrawer.Validators;

namespace CanvasDrawer
{
    internal class ProgramExecutor
    {
        private readonly ICommandValidator commandValidator;
        private readonly IDrawingCreator drawingCreator;
        private readonly IDrawer drawer;
        private Canvas? canvas;

        public ProgramExecutor(ICommandValidator commandValidator, IDrawingCreator drawingCreator, IDrawer drawer)
        {
            this.commandValidator = commandValidator;
            this.drawingCreator = drawingCreator;
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

                canvas = drawingCreator.CreateCanvas(command!);
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
