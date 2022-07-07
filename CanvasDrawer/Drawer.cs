using System.Drawing;
using System.Text;

namespace CanvasDrawer
{
    public class Drawer : IDrawer
    {
        public void DrawCanvas(Rectangle canvas)
        {
            var output = new StringBuilder();
            for (int i = 0; i < canvas.Width + 2; i++)
            {
                output.Append("-");
            }
            output.Append(Environment.NewLine);

            for (int i = 0; i < canvas.Height; i++)
            {
                output.Append("|");
                for (int j = 0; j < canvas.Width; j++)
                {
                    output.Append(" ");
                }
                output.AppendLine("|");
            }

            for (int i = 0; i < canvas.Width + 2; i++)
            {
                output.Append("-");
            }
            output.Append(Environment.NewLine);

            Console.WriteLine(output.ToString());
        }

        public void Draw(Rectangle canvas, IEnumerable<Rectangle> figures)
        {
            var startPosition = Console.GetCursorPosition();

            DrawCanvas(canvas);

            var endPosition = Console.GetCursorPosition();

            foreach (var figure in figures)
            {
                DrawFigure(startPosition, figure);
            }

            Console.SetCursorPosition(endPosition.Left, endPosition.Top);
        }

        private void DrawFigure((int Left, int Top) canvasStartPosition, Rectangle figure)
        {
            for (int xPos = figure.Left; xPos <= figure.Right; xPos++)
            {
                for (int yPos = figure.Top; yPos <= figure.Bottom; yPos++)
                {
                    var isRectangleBorderPosition = xPos == figure.Left || xPos == figure.Right || yPos == figure.Bottom || yPos == figure.Top;
                    if (isRectangleBorderPosition)
                    {
                        Console.SetCursorPosition(canvasStartPosition.Left + xPos, canvasStartPosition.Top + yPos);
                        Console.Write("x");
                    }
                }
            }
        }
    }
}
