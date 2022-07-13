using CanvasDrawer.Models;

namespace CanvasDrawer.Drawing
{
    public interface IDrawer
    {
        void Draw(Command command);
    }
}
