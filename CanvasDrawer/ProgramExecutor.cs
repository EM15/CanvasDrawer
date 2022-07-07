using CanvasDrawer.Creators;
using CanvasDrawer.Validators;
using System.Drawing;

namespace CanvasDrawer
{
    internal class ProgramExecutor
    {
        private readonly ICommandValidator commandValidator;
        private readonly IFigureCreator figureCreator;
        private readonly IDrawingValidator drawingValidator;
        private readonly IDrawer drawer;
        private Rectangle? canvas;

        public ProgramExecutor(ICommandValidator commandValidator, IFigureCreator figureCreator, IDrawingValidator drawingValidator, IDrawer drawer)
        {
            this.commandValidator = commandValidator;
            this.figureCreator = figureCreator;
            this.drawingValidator = drawingValidator;
            this.drawer = drawer;
        }

        public void ReadCanvas()
        {
            System.Console.WriteLine("Create a new Canvas");
            while (canvas is null)
            {
                var command = System.Console.ReadLine();
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
            var command = GetDrawnOnCanvasCommand();
            while (command != "Q")
            {
                var isValid = commandValidator.IsDrawingCommandValid(command);
                if (!isValid)
                {
                    ShowInvalidCommandMessage();
                    command = GetDrawnOnCanvasCommand();
                    continue;
                }

                try
                {
                    TryDrawFigureOrColor(command!);
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    command = GetDrawnOnCanvasCommand();
                }
            }
        }

        public void TryDrawFigureOrColor(string command)
        {
            if (command.StartsWith("B"))
            {
                var (position, color) = figureCreator.CreateBucketFill(command);
                drawer.ApplyBucketFill(position, color);
            }
            else
            {
                var figure = figureCreator.CreateFigure(command!);
                TryToDraw(figure);
            }
        }

        private void TryApplyBucketFill(Point point, char color)
        {
            var isBucketFillPointInsideCanvas = drawingValidator.IsBucketFillPointInsideCanvas(canvas.Value, point);
            if (isBucketFillPointInsideCanvas)
            {
                drawer.ApplyBucketFill(point, color);
            }
            else
            {
                System.Console.WriteLine("Point to apply Color is outside Canvas");
            }
        }

        private void TryToDraw(Rectangle figure)
        {
            var canFigureBeDrawn = drawingValidator.CanFigureBeDrawnInsideCanvas(canvas.Value, figure);
            if (canFigureBeDrawn)
            {
                drawer.Draw(figure);
            } 
            else
            {
                System.Console.WriteLine("Figure is outside canvas");
            }
        }

        private string? GetDrawnOnCanvasCommand()
        {
            System.Console.WriteLine("Draw on the canvas");
            return System.Console.ReadLine();
        }

        private void ShowInvalidCommandMessage() => System.Console.WriteLine("Invalid command");
    }
}
