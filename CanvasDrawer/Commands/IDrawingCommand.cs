namespace CanvasDrawer.Commands
{
    /// <summary>
    /// Used for all the commands that need previously a Canvas to be drawn inside.
    /// </summary>
    public interface IDrawingCommand
    {
        bool CanBeDrawnInsideCanvas(CanvasCommand canvas);
    }
}
