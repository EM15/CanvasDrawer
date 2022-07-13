using System.Drawing;
using System.Text.RegularExpressions;

namespace CanvasDrawer.Models
{
    public class BucketFill : Command, IDrawingCommand
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point DrawingValue { get; private set; }
        public char Color { get; private set; }

        public BucketFill(string command) : base(command)
        {
            var filledAreaRegex = new Regex(@"^B \d+ \d+ [a-zA-Z]$");
            if (!filledAreaRegex.IsMatch(command))
            {
                ThrowInvalidCommandException();
            }

            var extractValuesRegex = new Regex(@"\d+");
            var matches = extractValuesRegex.Matches(command);
            X = Convert.ToInt32(matches[0].Value);
            Y = Convert.ToInt32(matches[1].Value);
            Color = command.Last();
            DrawingValue = new Point(X, Y);
        }

        public bool CanBeDrawInsideCanvas(Canvas canvas) => canvas.DrawingValue.Contains(DrawingValue);
    }
}
