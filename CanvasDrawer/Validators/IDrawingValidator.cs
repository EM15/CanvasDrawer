using System.Drawing;

namespace CanvasDrawer.Validators
{
    public interface IDrawingValidator
    {
        bool CanFigureBeDrawnInsideCanvas(Rectangle canvas, Rectangle figureToBeDrawn);
        bool IsBucketFillPointInsideCanvas(Rectangle canvas, Point point);
    }
}
