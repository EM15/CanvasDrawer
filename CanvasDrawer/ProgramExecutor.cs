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
                drawer.Draw(canvas);
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

                CreateDrawing(command!);
                command = Console.ReadLine();
            }
        }

        private void CreateDrawing(string command)
        {
            try
            {
                var firstCommandLetter = command.First();
                switch (firstCommandLetter)
                {
                    case 'L':
                        var line = drawingCreator.CreateLine(command);
                        drawer.Draw(line);
                        break;
                    case 'R':
                        var rectangle = drawingCreator.CreateRectangle(command);
                        drawer.Draw(rectangle);
                        break;
                    case 'B':
                        throw new NotImplementedException("Bucket fill was not implemented yet");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowInvalidCommandMessage() => Console.WriteLine("InvalidCommand");
    }
}
