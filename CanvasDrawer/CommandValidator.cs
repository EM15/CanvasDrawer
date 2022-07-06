using System.Text.RegularExpressions;

namespace CanvasDrawer
{
    public class CommandValidator : ICommandValidator
    {
        public bool IsCanvasCommandValid(string? command)
        {
            if (string.IsNullOrEmpty(command))
            {
                return false;
            }

            var regex = new Regex(@"C \d+ \d+");
            return regex.IsMatch(command);
        }

        public bool IsDrawingCommandValid(string? command)
        {
            if (string.IsNullOrEmpty(command))
            {
                return false;
            }

            return false;
        }
    }
}
