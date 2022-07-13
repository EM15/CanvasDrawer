using System.Text.RegularExpressions;

namespace CanvasDrawer.Models
{
    public class Line : Command, IDrawingCommand
    {
        // TODO: Implement
        public static char CommandDirective = 'L';

        public int X1 { get; private set; }
        public int X2 { get; private set; }
        public int Y1 { get; private set; }
        public int Y2 { get; private set; }
        public System.Drawing.Rectangle DrawingValue { get; private set; }

        public Line(string command) : base(command)
        {
            var validationRegex = new Regex(@"^L \d+ \d+ \d+ \d+$");
            if (!validationRegex.IsMatch(command))
            {
                ThrowInvalidCommandException();
            }

            var extractValuesRegex = new Regex(@"\d+");
            var matches = extractValuesRegex.Matches(command);
            X1 = Convert.ToInt32(matches[0].Value);
            Y1 = Convert.ToInt32(matches[1].Value);
            X2 = Convert.ToInt32(matches[2].Value);
            Y2 = Convert.ToInt32(matches[3].Value);

            if (X1 != X2 && Y1 != Y2)
            {
                throw new ArgumentException("Only vertical and horizontal lines are allowed");
            }

            // (x, y) must be from left to right or top to bottom
            var x = X1 < X2 ? X1 : X2;
            var y = Y1 < Y2 ? Y1 : Y2;
            var width = Math.Abs(X2 - X1);
            var height = Math.Abs(Y2 - Y1);

            DrawingValue = new System.Drawing.Rectangle(x, y, width, height);
        }

        public bool CanBeDrawInsideCanvas(Canvas canvas) => canvas.DrawingValue.Contains(DrawingValue);
    }
}
