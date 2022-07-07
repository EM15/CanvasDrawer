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

        public void Draw(Rectangle rectangle)
        {
            var startPosition = Console.GetCursorPosition();

            //Draw(currentCanvas);

            //for (int i = 0; i < line.Length; i++)
            //{
            //    if (line.IsHorizontal)
            //    {
            //        Console.SetCursorPosition(startPosition.Left + 1 + i, startPosition.Top + 1);
            //    }
            //    else
            //    {
            //        Console.SetCursorPosition(startPosition.Left + 1, startPosition.Top + i + 1);
            //    }
            //    Console.Write("x");
            //}
        }
    }
}
