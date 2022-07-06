using System.Text.RegularExpressions;

namespace CanvasDrawer.Validators
{
    public class CommandValidator : ICommandValidator
    {
        public bool IsCanvasCommandValid(string? command)
        {
            if (string.IsNullOrEmpty(command))
            {
                return false;
            }

            var regex = new Regex(@"^C \d+ \d+$");
            return regex.IsMatch(command);
        }

        public bool IsDrawingCommandValid(string? command)
        {
            if (string.IsNullOrEmpty(command))
            {
                return false;
            }

            var lineRegex = new Regex(@"^L \d+ \d+ \d+ \d+$");
            var rectangleRegex = new Regex(@"^R \d+ \d+ \d+ \d+$");
            var filledAreaRegex = new Regex(@"^B \d+ \d+ .$");

            return lineRegex.IsMatch(command)
                || rectangleRegex.IsMatch(command)
                || filledAreaRegex.IsMatch(command);
        }
    }
}
