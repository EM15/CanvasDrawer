using System.Text.RegularExpressions;

namespace CanvasDrawer.Models
{
    public class Canvas : Command
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public System.Drawing.Rectangle DrawingValue { get; private set; }

        public Canvas(int width, int height) : this($"C {width} {height}") { }
        public Canvas(string command) : base(command)
        {
            var validationRegex = new Regex(@"^C \d+ \d+$");
            if (!validationRegex.IsMatch(command))
            {
                ThrowInvalidCommandException();
            }

            var extractValuesRegex = new Regex(@"\d+");
            var matches = extractValuesRegex.Matches(command);

            Width = Convert.ToInt32(matches[0].Value);
            Height = Convert.ToInt32(matches[1].Value);

            if (Width == 0 || Height == 0)
            {
                throw new ArgumentException("Canvas width/height can't be 0");
            }

            DrawingValue = new System.Drawing.Rectangle(1, 1, Width, Height);
        }
    }
}
