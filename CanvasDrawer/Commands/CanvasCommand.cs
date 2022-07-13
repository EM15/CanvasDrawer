using CanvasDrawer.Exceptions;
using System.Drawing;
using System.Text.RegularExpressions;

namespace CanvasDrawer.Commands
{
    public class CanvasCommand : Command
    {
        public const char CommandDirective = 'C';
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Rectangle DrawingValue { get; private set; }

        public CanvasCommand(int width, int height) : this($"{CommandDirective} {width} {height}") { }
        public CanvasCommand(string command) : base(command)
        {
            var validationRegex = new Regex(@"^C \d+ \d+$");
            if (!validationRegex.IsMatch(command))
            {
                throw new InvalidCommandException();
            }

            var extractValuesRegex = new Regex(@"\d+");
            var matches = extractValuesRegex.Matches(command);

            Width = Convert.ToInt32(matches[0].Value);
            Height = Convert.ToInt32(matches[1].Value);

            if (Width == 0 || Height == 0)
            {
                throw new ArgumentException("Canvas width/height can't be 0");
            }

            DrawingValue = new Rectangle(1, 1, Width, Height);
        }
    }
}
