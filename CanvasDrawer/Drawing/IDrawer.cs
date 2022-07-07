using System.Drawing;

namespace CanvasDrawer.Drawing
{
    public interface IDrawer
    {
        void DrawCanvas(Rectangle canvas);
        void Draw(Rectangle figure);
        void ApplyBucketFill(Point point, char color);
    }
}
