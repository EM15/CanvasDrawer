using CanvasDrawer.Drawings;
using System.Text;

namespace CanvasDrawer
{
    public class Drawer : IDrawer
    {
        public void Draw(Canvas canvas)
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

            Console.Write(output.ToString());
        }

        public void Draw(Line line)
        {
            throw new NotImplementedException();
        }

        public void Draw(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }
    }
}
