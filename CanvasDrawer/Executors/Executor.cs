using CanvasDrawer.Console;
using CanvasDrawer.Creators;
using CanvasDrawer.Drawing;
using CanvasDrawer.Validators;
using System.Drawing;

namespace CanvasDrawer
{
    internal class Executor
    {
        private readonly ICommandValidator commandValidator;
        private readonly IFigureCreator figureCreator;
        private readonly IDrawingValidator drawingValidator;
        private readonly IDrawer drawer;
        private readonly IConsoleReader consoleReader;
        private readonly IConsoleWriter consoleWriter;
        private Rectangle? canvas;

        public Executor(ICommandValidator commandValidator, IFigureCreator figureCreator, IDrawingValidator drawingValidator, IDrawer drawer,
            IConsoleReader consoleReader, IConsoleWriter consoleWriter)
        {
            this.commandValidator = commandValidator;
            this.figureCreator = figureCreator;
            this.drawingValidator = drawingValidator;
            this.drawer = drawer;
            this.consoleReader = consoleReader;
            this.consoleWriter = consoleWriter;
        }

        public void ReadCanvasCommand()
        {
            consoleWriter.WriteLine("Create a new Canvas");
            while (canvas is null)
            {
                var command = consoleReader.ReadLine();
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

        public void ReadDrawingCommands()
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
                catch (Exception ex)
                {
                    consoleWriter.WriteLine(ex.Message);
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
                TryApplyBucketFill(position, color);
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
                consoleWriter.WriteLine("Point to apply Color is outside Canvas");
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
                consoleWriter.WriteLine("Figure is outside canvas");
            }
        }

        private string? GetDrawnOnCanvasCommand()
        {
            consoleWriter.WriteLine("Draw on the canvas");
            return consoleReader.ReadLine();
        }

        private void ShowInvalidCommandMessage() => consoleWriter.WriteLine("Invalid command");
    }
}
