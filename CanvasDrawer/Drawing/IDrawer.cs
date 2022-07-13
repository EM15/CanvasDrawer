using CanvasDrawer.Commands;

namespace CanvasDrawer.Drawing
{
    public interface IDrawer
    {
        void Draw(Command command);
    }
}
