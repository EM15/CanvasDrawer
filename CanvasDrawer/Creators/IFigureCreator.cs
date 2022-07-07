using System.Drawing;

namespace CanvasDrawer.Creators
{
    public interface IFigureCreator
    {
        Rectangle CreateCanvas(string command);
        (Point position, char color) CreateBucketFill(string command);
        Rectangle CreateFigure(string command);
    }
}
