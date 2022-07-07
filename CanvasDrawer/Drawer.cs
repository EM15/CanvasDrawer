using System.Drawing;

namespace CanvasDrawer
{
    public class Drawer : IDrawer
    {
        private const string canvasTopBottomDelimiter = "-";
        private const string canvasLeftRightDelimiter = "|";
        private string[,]? output;

        private void CreateCanvas(Rectangle canvas)
        {
            output = new string[canvas.Height + 2, canvas.Width + 2];
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

                    var isCanvasBorderLeftOrRight = (y != 0 && y != yLength - 1) && (x == 0 || x == xLength - 1);
                    if (isCanvasBorderLeftOrRight)
                    {
                        output[y, x] = canvasLeftRightDelimiter;
                        continue;
                    }

                    output[y, x] = " ";
                }
            }
        }

        public void Draw(Rectangle figure)
        {
            if (output is null)
            {
                CreateCanvas(figure);
                WriteOutput();
            }
            //else
            //var startPosition = Console.GetCursorPosition();

            //DrawCanvas(canvas);

            //var endPosition = Console.GetCursorPosition();

            //foreach (var figure in figures)
            //{
            //    DrawFigure(startPosition, figure);
            //}

            //Console.SetCursorPosition(endPosition.Left, endPosition.Top);
        }

        //private void DrawFigure((int Left, int Top) canvasStartPosition, Rectangle figure)
        //{
        //    for (int xPos = figure.Left; xPos <= figure.Right; xPos++)
        //    {
        //        for (int yPos = figure.Top; yPos <= figure.Bottom; yPos++)
        //        {
        //            var isRectangleBorderPosition = xPos == figure.Left || xPos == figure.Right || yPos == figure.Bottom || yPos == figure.Top;
        //            if (isRectangleBorderPosition)
        //            {
        //                Console.SetCursorPosition(canvasStartPosition.Left + xPos, canvasStartPosition.Top + yPos);
        //                Console.Write("x");
        //            }
        //        }
        //    }
        //}

        private void WriteOutput()
        {
            if (output != null)
            {
                for (int x = 0; x < output.GetLength(0); x++)
                {
                    for (int y = 0; y < output.GetLength(1); y++)
                    {
                        Console.Write(output[x, y]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
