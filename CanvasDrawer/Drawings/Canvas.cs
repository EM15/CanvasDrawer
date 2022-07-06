using System.Text.RegularExpressions;

namespace CanvasDrawer.Drawings
{
    public class Canvas
    {
        public readonly int Width;
        public readonly int Height;

        public Canvas(string command)
        {
            var regex = new Regex(@"\d+");
            var matches = regex.Matches(command);
            Width = Convert.ToInt32(matches[0].Value);
            Height = Convert.ToInt32(matches[1].Value);
        }
    }
}
