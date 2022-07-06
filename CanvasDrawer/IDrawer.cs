using CanvasDrawer.Drawings;

namespace CanvasDrawer
{
    public interface IDrawer
    {
        void Draw(Canvas canvas);
        void Draw(Line line);
        void Draw(Rectangle rectangle);
    }
}
