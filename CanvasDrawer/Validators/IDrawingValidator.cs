using System.Drawing;

namespace CanvasDrawer.Validators
{
    public interface IDrawingValidator
    {
        bool CanFigureBeDraw(Rectangle canvas, IEnumerable<Rectangle> figuresAlreadyDraw, Rectangle figureToBeDraw);
    }
}
