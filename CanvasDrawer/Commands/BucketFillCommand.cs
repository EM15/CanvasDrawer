using CanvasDrawer.Exceptions;
using System.Drawing;
using System.Text.RegularExpressions;

namespace CanvasDrawer.Commands
{
    public class BucketFillCommand : Command, IDrawingCommand
    {
        public const char CommandDirective = 'B';
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point DrawingValue { get; private set; }
        public char Color { get; private set; }

        public BucketFillCommand(int x, int y, char color) : this($"{CommandDirective} {x} {y} {color}") { }
        public BucketFillCommand(string command) : base(command)
        {
            var filledAreaRegex = new Regex(@$"^{CommandDirective} \d+ \d+ [a-zA-Z]$");
            if (!filledAreaRegex.IsMatch(command))
            {
                throw new InvalidCommandException();
            }

            var extractValuesRegex = new Regex(@"\d+");
            var matches = extractValuesRegex.Matches(command);
            X = Convert.ToInt32(matches[0].Value);
            Y = Convert.ToInt32(matches[1].Value);
            Color = command.Last();
            DrawingValue = new Point(X, Y);
        }

        public bool CanBeDrawnInsideCanvas(CanvasCommand canvas)
        {
            // Contains overload using the Point does include the borders
            var rectangle = new Rectangle(DrawingValue, new Size(0, 0));
            return canvas.DrawingValue.Contains(rectangle);
        }
    }
}
