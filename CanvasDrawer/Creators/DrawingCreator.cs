using CanvasDrawer.Drawings;
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

        public Line CreateLine(string command)
        {
            var regex = new Regex(@"\d+");
            var matches = regex.Matches(command);
            var x1 = Convert.ToInt32(matches[0].Value);
            var y1 = Convert.ToInt32(matches[1].Value);
            var x2 = Convert.ToInt32(matches[2].Value);
            var y2 = Convert.ToInt32(matches[3].Value);
            return new Line(x1, y1, x2, y2);
        }

        public Rectangle CreateRectangle(string command)
        {
            var regex = new Regex(@"\d+");
            var matches = regex.Matches(command);
            var x1 = Convert.ToInt32(matches[0].Value);
            var y1 = Convert.ToInt32(matches[1].Value);
            var x2 = Convert.ToInt32(matches[2].Value);
            var y2 = Convert.ToInt32(matches[3].Value);
            return new Rectangle(x1, y1, x2, y2);
        }

    }
}
