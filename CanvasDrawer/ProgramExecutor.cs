using CanvasDrawer.Creators;
using CanvasDrawer.Validators;
using System.Drawing;

namespace CanvasDrawer
{
    internal class ProgramExecutor
    {
        private readonly ICommandValidator commandValidator;
        private readonly IDrawingCreator drawingCreator;
        private readonly IDrawer drawer;
        private Rectangle? canvas;

        public ProgramExecutor(ICommandValidator commandValidator, IDrawingCreator drawingCreator, IDrawer drawer)
        {
            this.commandValidator = commandValidator;
            this.drawingCreator = drawingCreator;
            this.drawer = drawer;
        }

        public void ReadCanvas()
        {
            Console.WriteLine("Create a new Canvas");
            while (canvas is null)
            {
                var command = Console.ReadLine();
                var isValid = commandValidator.IsCanvasCommandValid(command);
                if (!isValid)
                {
                    ShowInvalidCommandMessage();
                    continue;
                }

                canvas = drawingCreator.CreateCanvas(command!);
                drawer.DrawCanvas(canvas.Value);
            }
        }

        public void ReadCommands()
        {
            Console.WriteLine("Draw on the canvas");
            var command = Console.ReadLine();
            while (command != "Q")
            {
                var isValid = commandValidator.IsDrawingCommandValid(command);
                if (!isValid)
                {
                    ShowInvalidCommandMessage();
                    command = Console.ReadLine();
                    continue;
                }

                var drawing = drawingCreator.CreateDrawing(command!);
                drawer.Draw(drawing);

                command = Console.ReadLine();
            }
        }

        private void ShowInvalidCommandMessage() => Console.WriteLine("InvalidCommand");
    }
}
