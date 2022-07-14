using CanvasDrawer.Commands;
using CanvasDrawer.Console;
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
        private CanvasCommand? canvas;

        public Drawer(IConsoleWriter consoleWriter)
        {
            this.consoleWriter = consoleWriter;
        }

        private void ApplyCanvas(CanvasCommand canvas)
        {
            this.canvas = canvas;
            var rectangle = canvas.DrawingValue;

            // If Canvas is a Rectangle from (1, 1) to (2, 2) it's width/height is 1.
            // From x1 = 1 to x2 = 2 the distance is 1. But there are two points.
            // We need to sum 3: two for the delimeters and one for the extra point.
            var xPoints = rectangle.Width + 3;
            var yPoints = rectangle.Height + 3;
            output = new char[yPoints, xPoints];

            for (int y = 0; y < yPoints; y++)
            {
                for (int x = 0; x < xPoints; x++)
                {
                    var isCanvasBorderTopOrBottom = y == 0 || y == yPoints - 1;
                    if (isCanvasBorderTopOrBottom)
                    {
                        output[y, x] = canvasTopBottomDelimiter;
                        continue;
                    }

                    var isCanvasBorderLeftOrRight = y != 0 && y != yPoints - 1 && (x == 0 || x == xPoints - 1);
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

            if (command is CanvasCommand canvas)
            {
                ApplyCanvas(canvas);
            }
            else if (command is BucketFillCommand bucketFill)
            {
                ApplyBucketFill(bucketFill.DrawingValue, bucketFill.Color);
            }
            else if (command is RectangleCommand rectangle)
            {
                ApplyRectangle(rectangle.DrawingValue);
            }
            else if (command is LineCommand line)
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

        private void ApplyRectangle(Rectangle rectangle)
        {
            for (int x = rectangle.Left; x <= rectangle.Right; x++)
            {
                for (int y = rectangle.Top; y <= rectangle.Bottom; y++)
                {
                    var isRectangleBorderPosition = x == rectangle.Left || x == rectangle.Right || y == rectangle.Bottom || y == rectangle.Top;
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

            if (!drawingCommand.CanBeDrawnInsideCanvas(canvas))
            {
                throw new InvalidOperationException("Command can't be applied to current canvas");
            }
        }
    }
}
