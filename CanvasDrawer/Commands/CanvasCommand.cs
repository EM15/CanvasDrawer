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
            var validationRegex = new Regex(@$"^{CommandDirective} \d+ \d+$");
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

            // Following the example in the documentation:
            // A Canvas with Width = 2 and Height = 2 means that it will be a rectangle from (1, 1) to (2, 2).
            // That's why we need to substract 1 to Width and Height. If not rectangle would be from (1, 1) to (3, 3)
            DrawingValue = new Rectangle(1, 1, Width - 1, Height - 1);
        }
    }
}
