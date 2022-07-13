using System.Text.RegularExpressions;

namespace CanvasDrawer.Models
{
    public class Line : Command, IDrawingCommand
    {
        public int X1 { get; private set; }
        public int X2 { get; private set; }
        public int Y1 { get; private set; }
        public int Y2 { get; private set; }
        public System.Drawing.Rectangle DrawingValue { get; private set; }

        public Line(string command) : base(command)
        {
            var regex = new Regex(@"\d+");
            var matches = regex.Matches(command);
            X1 = Convert.ToInt32(matches[0].Value);
            Y1 = Convert.ToInt32(matches[1].Value);
            X2 = Convert.ToInt32(matches[2].Value);
            Y2 = Convert.ToInt32(matches[3].Value);

            if (X1 != X2 && Y1 != Y2)
            {
                throw new ArgumentException("Only vertical and horizontal lines are allowed");
            }

            // TODO: Check if this is really needed
            // We switch the values in case the user inserts the line drawed from right to left or from top to bottom.
            if (X1 > X2)
            {
                var x1OriginalValue = X1;
                X1 = X2;
                X2 = x1OriginalValue;
            }

            if (Y1 > Y2)
            {
                var y1OriginalValue = Y1;
                Y1 = Y2;
                Y2 = y1OriginalValue;
            }

            DrawingValue = new System.Drawing.Rectangle(X1, Y1, X2 - X1, Y2 - Y1);
        }

        public bool CanBeAppliedToCanvas(Canvas canvas) => canvas.DrawingValue.Contains(DrawingValue);
    }
}
