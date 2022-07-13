using CanvasDrawer.Exceptions;
using System.Drawing;
using System.Text.RegularExpressions;

namespace CanvasDrawer.Commands
{
    public class RectangleCommand : Command, IDrawingCommand
    {
        public const char CommandDirective = 'R';

        public int X1 { get; private set; }
        public int X2 { get; private set; }
        public int Y1 { get; private set; }
        public int Y2 { get; private set; }
        public Rectangle DrawingValue { get; private set; }

        public RectangleCommand(int x1, int y1, int x2, int y2) : this($"{CommandDirective} {x1} {y1} {x2} {y2}") { }

        public RectangleCommand(string command) : base(command)
        {
            var validationRegex = new Regex(@"^R \d+ \d+ \d+ \d+$");
            if (!validationRegex.IsMatch(command))
            {
                throw new InvalidCommandException();
            }

            var extractValuesRegex = new Regex(@"\d+");
            var matches = extractValuesRegex.Matches(command);
            X1 = Convert.ToInt32(matches[0].Value);
            Y1 = Convert.ToInt32(matches[1].Value);
            X2 = Convert.ToInt32(matches[2].Value);
            Y2 = Convert.ToInt32(matches[3].Value);

            if (X1 >= X2 || Y1 >= Y2)
            {
                throw new ArgumentException("(x1, y1) must be upper left corner. (x2, y2) must be lower right corner");
            }

            DrawingValue = new Rectangle(X1, Y1, X2 - X1, Y2 - Y1);
        }

        public bool CanBeDrawInsideCanvas(CanvasCommand canvas) => canvas.DrawingValue.Contains(DrawingValue);
    }
}
