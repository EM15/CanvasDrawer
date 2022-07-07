using System.Drawing;

namespace CanvasDrawer
{
    public class Drawer : IDrawer
    {
        private const string canvasTopBottomDelimiter = "-";
        private const string canvasLeftRightDelimiter = "|";
        private const string emptySpace = " ";
        private const string figureBorder = "x";
        private string[,]? output;

        public void DrawCanvas(Rectangle canvas)
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

                    output[y, x] = emptySpace;
                }
            }

            WriteOutput();
        }

        public void Draw(Rectangle figure)
        {
            AddFigureToOutput(figure);
            WriteOutput();
        }

        public void ApplyBucketFill(Point point, char color)
        {
            var valueOnPoint = output[point.Y, point.X];

            //TryApplyColorLeft()
            //output[point.Y, point.X] = 
            
        }

        private void TryApplyColorLeft()
        {

        }

        private void TryApplyColorRight()
        {

        }

        private void TryApplyColorTop()
        {

        }

        private void TryApplyColorBottom()
        {

        }

        private void AddFigureToOutput(Rectangle figure)
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
