using CanvasDrawer.Drawings;
using System.Drawing;
using System.Text.RegularExpressions;

namespace CanvasDrawer.Creators
{
    public class DrawingCreator : IDrawingCreator
    {
        public Canvas CreateCanvas(string command)
        {
            var regex = new Regex(@"\d+");
            var matches = regex.Matches(command);
            var width = Convert.ToInt32(matches[0].Value);
            var height = Convert.ToInt32(matches[1].Value);

            return new Canvas(width, height);
        }

        public Rectangle CreateDrawing(string command)
        {
            var regex = new Regex(@"\d+");
            var matches = regex.Matches(command);
            var x1 = Convert.ToInt32(matches[0].Value);
            var y1 = Convert.ToInt32(matches[1].Value);
            var x2 = Convert.ToInt32(matches[2].Value);
            var y2 = Convert.ToInt32(matches[3].Value);

            if (command.StartsWith("L") && x1 != x2 && y1 != y2)
            {
                throw new ArgumentException("Only vertical and horizontal lines are allowed");
            }

            if (command.StartsWith("R") && (x1 >= x2 || y1 >= y2))
            {
                throw new ArgumentException("(x1, y1) must be upper left corner. (x2, y2) must be lower right corner");
            }

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

    }
}
