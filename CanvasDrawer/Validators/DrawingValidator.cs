using System.Drawing;

namespace CanvasDrawer.Validators
{
    public class DrawingValidator : IDrawingValidator
    {
        public bool CanFigureBeDrawnInsideCanvas(Rectangle canvas, Rectangle figureToBeDrawn)
        {
            var figureIsInsideCanvas = canvas.Contains(figureToBeDrawn);
            return figureIsInsideCanvas;
        }

        public bool IsBucketFillPointInsideCanvas(Rectangle canvas, Point point)
        {
            return canvas.Contains(point);
        }
    }
}
