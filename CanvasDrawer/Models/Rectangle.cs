using System.Text.RegularExpressions;

namespace CanvasDrawer.Models
{
    public class Rectangle : Command, IDrawingCommand
    {
        public int X1 { get; private set; }
        public int X2 { get; private set; }
        public int Y1 { get; private set; }
        public int Y2 { get; private set; }
        public System.Drawing.Rectangle DrawingValue { get; private set; }

        public Rectangle(int x1, int y1, int x2, int y2) : this($"R {x1} {y1} {x2} {y2}") { }

        public Rectangle(string command) : base(command)
        {
            var validationRegex = new Regex(@"^R \d+ \d+ \d+ \d+$");
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

            if (X1 >= X2 || Y1 >= Y2)
            {
                throw new ArgumentException("(x1, y1) must be upper left corner. (x2, y2) must be lower right corner");
            }

            DrawingValue = new System.Drawing.Rectangle(X1, Y1, X2 - X1, Y2 - Y1);
        }

        public bool CanBeDrawInsideCanvas(Canvas canvas) => canvas.DrawingValue.Contains(DrawingValue);
    }
}
