using System.Text.RegularExpressions;

namespace CanvasDrawer.Validators
{
    public class CommandValidator : ICommandValidator
    {
        public bool IsCommandValid(string? command)
        {
            if (string.IsNullOrEmpty(command))
            {
                return false;
            }

            var canvasRegex = new Regex(@"^C \d+ \d+$");
            var lineRegex = new Regex(@"^L \d+ \d+ \d+ \d+$");
            var rectangleRegex = new Regex(@"^R \d+ \d+ \d+ \d+$");
            var filledAreaRegex = new Regex(@"^B \d+ \d+ [a-zA-Z]$");

            return
                canvasRegex.IsMatch(command)
                || lineRegex.IsMatch(command)
                || rectangleRegex.IsMatch(command)
                || filledAreaRegex.IsMatch(command);
        }
    }
}
