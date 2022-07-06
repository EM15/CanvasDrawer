using CanvasDrawer.Drawings;

namespace CanvasDrawer.Creators
{
    public interface IDrawingCreator
    {
        Canvas CreateCanvas(string command);
        Line CreateLine(string command);
        Rectangle CreateRectangle(string command);
    }
}
