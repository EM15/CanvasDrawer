using CanvasDrawer.Drawings;
using System.Drawing;

namespace CanvasDrawer.Creators
{
    public interface IDrawingCreator
    {
        Canvas CreateCanvas(string command);
        Rectangle CreateDrawing(string command);
    }
}
