using CanvasDrawer.Drawings;
using System.Drawing;

namespace CanvasDrawer
{
    public interface IDrawer
    {
        void Draw(Canvas canvas);
        void Draw(Rectangle rectangle);
    }
}
