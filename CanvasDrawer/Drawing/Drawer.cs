using CanvasDrawer.Console;
using CanvasDrawer.Models;
using System.Drawing;
using System.Text;

namespace CanvasDrawer.Drawing
{
    public class Drawer : IDrawer
    {
        private const char canvasTopBottomDelimiter = '-';
        private const char canvasLeftRightDelimiter = '|';
        private const char emptySpace = ' ';
        private const char figureBorder = 'x';
        private readonly IConsoleWriter consoleWriter;
        private char[,]? output;
        private Canvas? canvas;

        public Drawer(IConsoleWriter consoleWriter)
        {
            this.consoleWriter = consoleWriter;
        }

        private void ApplyCanvas(Canvas canvas)
        {
            this.canvas = canvas;
            var rectangle = canvas.DrawingValue;

            output = new char[rectangle.Height + 2, rectangle.Width + 2];
            var yLength = output.GetLength(0);
            var xLength = output.GetLength(1);
            for (int y = 0; y < yLength; y++)
            {
                for (int x = 0; x < xLength; x++)
                {
                    var isCanvasBorderTopOrBottom = y == 0 || y == yLength - 1;
                    if (isCanvasBorderTopOrBottom)
                    {
                        output[y, x] = canvasTopBottomDelimiter;
                        continue;
                    }

                    var isCanvasBorderLeftOrRight = y != 0 && y != yLength - 1 && (x == 0 || x == xLength - 1);
                    if (isCanvasBorderLeftOrRight)
                    {
                        output[y, x] = canvasLeftRightDelimiter;
                        continue;
                    }

                    output[y, x] = emptySpace;
                }
            }
        }

        public void Draw(Command command)
        {
            if (command is IDrawingCommand drawingCommand)
            {
                ValidateOrThrow(drawingCommand);
            }

            if (command is Canvas canvas)
            {
                ApplyCanvas(canvas);
            }
            else if (command is BucketFill bucketFill)
            {
                ApplyBucketFill(bucketFill.DrawingValue, bucketFill.Color);
            }
            else if (command is Models.Rectangle rectangle)
            {
                ApplyRectangle(rectangle.DrawingValue);
            }
            else if (command is Line line)
            {
                ApplyRectangle(line.DrawingValue);
            }

            WriteOutput();
        }

        private void ApplyBucketFill(Point point, char color)
        {
            var initialValue = output[point.Y, point.X];
            TryApplyColorInAllDirections(point, color, initialValue);
        }

        private void TryApplyColorInAllDirections(Point point, char color, char initialValue)
        {
            var pointToLeft = new Point(point.X - 1, point.Y);
            TryApplyColor(pointToLeft, color, initialValue);
            var pointToRight = new Point(point.X + 1, point.Y);
            TryApplyColor(pointToRight, color, initialValue);
            var pointToTop = new Point(point.X, point.Y - 1);
            TryApplyColor(pointToTop, color, initialValue);
            var pointToBottom = new Point(point.X, point.Y + 1);
            TryApplyColor(pointToBottom, color, initialValue);
        }

        private void TryApplyColor(Point point, char color, char initialValue)
        {
            var currentValue = output[point.Y, point.X];
            if (currentValue == initialValue)
            {
                output[point.Y, point.X] = color;
                TryApplyColorInAllDirections(point, color, currentValue);
            }
        }

        private void ApplyRectangle(System.Drawing.Rectangle figure)
        {
            for (int x = figure.Left; x <= figure.Right; x++)
            {
                for (int y = figure.Top; y <= figure.Bottom; y++)
                {
                    var isRectangleBorderPosition = x == figure.Left || x == figure.Right || y == figure.Bottom || y == figure.Top;
                    if (isRectangleBorderPosition)
                    {
                        output[y, x] = figureBorder;
                    }
                }
            }
        }

        private void WriteOutput()
        {
            var sbOutput = new StringBuilder();

            for (int y = 0; y < output.GetLength(0); y++)
            {
                for (int x = 0; x < output.GetLength(1); x++)
                {
                    sbOutput.Append(output[y, x]);
                }
                sbOutput.AppendLine();
            }

            consoleWriter.Write(sbOutput.ToString());
        }

        private void ValidateOrThrow(IDrawingCommand drawingCommand)
        {
            if (canvas is null)
            {
                throw new InvalidOperationException("Canvas was not initialized");
            }

            if (!drawingCommand.CanBeAppliedToCanvas(canvas))
            {
                throw new InvalidOperationException("Command can't be applied to current canvas");
            }
        }
    }
}
