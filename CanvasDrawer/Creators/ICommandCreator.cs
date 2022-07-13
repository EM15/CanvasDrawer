using CanvasDrawer.Models;

namespace CanvasDrawer.Creators
{
    public interface ICommandCreator
    {
        Command CreateCommand(string? commandInputText);
    }
}
