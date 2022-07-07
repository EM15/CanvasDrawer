using CanvasDrawer.Drawings;
using System.Drawing;
using System.Text;

namespace CanvasDrawer
{
    public class Drawer : IDrawer
    {
        private Canvas? currentCanvas { get; set; }

        public void Draw(Canvas canvas)
        {
            currentCanvas = canvas;
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

        private void DrawCurrentCanvas()
        {
            
        }

        public void Draw(Line line)
        {
            var startPosition = Console.GetCursorPosition();

            DrawCurrentCanvas();

            for (int i = 0; i < line.Length; i++)
            {
                if (line.IsHorizontal)
                {
                    Console.SetCursorPosition(startPosition.Left + 1 + i, startPosition.Top + 1);
                }
                else
                {
                    Console.SetCursorPosition(startPosition.Left + 1, startPosition.Top + i + 1);
                }
                Console.Write("x");
            }
        }

        public void Draw(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }
    }
}
