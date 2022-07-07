using System.Drawing;

namespace CanvasDrawer.Creators
{
    public interface IDrawingCreator
    {
        Rectangle CreateCanvas(string command);
        Rectangle CreateDrawing(string command);
    }
}
