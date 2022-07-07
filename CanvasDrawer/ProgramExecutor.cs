using CanvasDrawer.Creators;
using CanvasDrawer.Validators;
using System.Drawing;

namespace CanvasDrawer
{
    internal class ProgramExecutor
    {
        private readonly ICommandValidator commandValidator;
        private readonly IFigureCreator figureCreator;
        private readonly IDrawer drawer;
        private Rectangle? canvas;
        private IList<Rectangle> drawings = new List<Rectangle>();

        public ProgramExecutor(ICommandValidator commandValidator, IFigureCreator figureCreator, IDrawer drawer)
        {
            this.commandValidator = commandValidator;
            this.figureCreator = figureCreator;
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

                canvas = figureCreator.CreateCanvas(command!);
                drawer.DrawCanvas(canvas.Value);
            }
        }

        public void ReadCommands()
        {
            ShowDrawOnCanvasMessage();
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

                var drawing = figureCreator.CreateDrawing(command!);
                drawings.Add(drawing);
                drawer.Draw(canvas.Value, drawings);

                ShowDrawOnCanvasMessage();
                command = Console.ReadLine();
            }
        }

        private void ShowDrawOnCanvasMessage() => Console.WriteLine("Draw on the canvas");

        private void ShowInvalidCommandMessage() => Console.WriteLine("Invalid command");
    }
}
