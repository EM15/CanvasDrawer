using System.Drawing;

namespace CanvasDrawer
{
    public interface IDrawer
    {
        void DrawCanvas(Rectangle canvas);
        void Draw(Rectangle canvas, Rectangle rectangle);
    }
}
