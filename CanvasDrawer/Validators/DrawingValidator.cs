using System.Drawing;

namespace CanvasDrawer.Validators
{
    public class DrawingValidator : IDrawingValidator
    {
        public bool CanFigureBeDraw(Rectangle canvas, IEnumerable<Rectangle> figuresAlreadyDraw, Rectangle figureToBeDraw)
        {
            var figureIsOutsideCanvasOrGoesOutOfBounds = !canvas.Contains(figureToBeDraw);
            if (figureIsOutsideCanvasOrGoesOutOfBounds)
            {
                return false;
            }

            return true;
        }
    }
}
