using System.Drawing;

namespace CanvasDrawer.Creators
{
    public interface IFigureCreator
    {
        Rectangle CreateCanvas(string command);
        Rectangle CreateFigure(string command);
    }
}
