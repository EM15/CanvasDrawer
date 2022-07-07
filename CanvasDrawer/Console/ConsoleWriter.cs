namespace CanvasDrawer.Console
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string? value) => System.Console.Write(value);

        public void WriteLine(string? value) => System.Console.WriteLine(value);
    }
}
