using CanvasDrawer.Console;
using CanvasDrawer.Creators;
using CanvasDrawer.Drawing;

namespace CanvasDrawer
{
    public class ProgramExecutor
    {
        private readonly ICommandCreator commandCreator;
        private readonly IDrawer drawer;
        private readonly IConsoleReader consoleReader;
        private readonly IConsoleWriter consoleWriter;

        public ProgramExecutor(ICommandCreator commandCreator, IDrawer drawer, IConsoleReader consoleReader, IConsoleWriter consoleWriter)
        {
            this.commandCreator = commandCreator;
            this.drawer = drawer;
            this.consoleReader = consoleReader;
            this.consoleWriter = consoleWriter;
        }

        public void Execute()
        {
            var commandInputText = GetCommandInputText();
            while (commandInputText != "Q")
            {
                try
                {
                    var command = commandCreator.CreateCommand(commandInputText);
                    drawer.Draw(command);
                }
                catch (Exception ex)
                {
                    consoleWriter.WriteLine(ex.Message);
                }
                finally
                {
                    commandInputText = GetCommandInputText();
                }
            }
        }

        private string? GetCommandInputText()
        {
            consoleWriter.WriteLine("Please insert command");
            return consoleReader.ReadLine();
        }
    }
}
