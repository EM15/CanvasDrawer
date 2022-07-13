using CanvasDrawer.Commands;

namespace CanvasDrawer.Creators
{
    public interface ICommandCreator
    {
        Command CreateCommand(string commandInputText);
    }
}
