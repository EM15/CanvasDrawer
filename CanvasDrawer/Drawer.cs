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

        private void AddFigureToOutput(Rectangle figure)
        {
            for (int y = figure.Top; y <= figure.Bottom; y++)
            {
                for (int x = figure.Left; x <= figure.Right; x++)
                {
                    output[y, x] = "x";
                }
            }
        }

        public void Draw(Rectangle figure)
        {
            if (output is null)
            {
                CreateCanvas(figure);
            }
            else
            {
                AddFigureToOutput(figure);
            }

            WriteOutput();
        }

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
