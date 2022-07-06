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
    }
}
