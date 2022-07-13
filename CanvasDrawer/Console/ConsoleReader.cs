namespace CanvasDrawer.Console
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine() => System.Console.ReadLine() ?? string.Empty;
    }
}
