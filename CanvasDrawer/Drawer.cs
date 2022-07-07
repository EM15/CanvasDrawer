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

        public void Draw(Rectangle canvas, Rectangle rectangle)
        {
            var startPosition = Console.GetCursorPosition();

            DrawCanvas(canvas);

            var endPosition = Console.GetCursorPosition();

            for (int xPos = rectangle.Left; xPos <= rectangle.Right ; xPos++)
            {
                for (int yPos = rectangle.Top; yPos <= rectangle.Bottom; yPos++)
                {
                    var isRectangleBorderPosition = xPos == rectangle.Left || xPos == rectangle.Right || yPos == rectangle.Bottom || yPos == rectangle.Top;
                    if (isRectangleBorderPosition)
                    {
                        Console.SetCursorPosition(startPosition.Left + xPos, startPosition.Top + yPos);
                        Console.Write("x");
                    }
                }
            }

            Console.SetCursorPosition(endPosition.Left, endPosition.Top);
        }
    }
}
