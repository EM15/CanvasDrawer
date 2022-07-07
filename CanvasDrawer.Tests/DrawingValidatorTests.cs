using CanvasDrawer.Validators;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class DrawingValidatorTests
    {
        private readonly DrawingValidator drawingValidator = new DrawingValidator();

        [Fact]
        public void DrawFigureOutsideCanvasShouldBeInvalid()
        {
            var canvas = new Rectangle(0, 0, 10, 10);
            var figure = new Rectangle(10, 10, 1, 1);
            var canBeDrawn = drawingValidator.CanFigureBeDrawnInsideCanvas(canvas, figure);
            Assert.False(canBeDrawn);
        }

        [Fact]
        public void DrawFigureThatGoesOutOfBoundsShouldBeInvalid()
        {
            var canvas = new Rectangle(0, 0, 10, 10);
            var figure = new Rectangle(0, 0, 11, 11);
            var canBeDrawn = drawingValidator.CanFigureBeDrawnInsideCanvas(canvas, figure);
            Assert.False(canBeDrawn);
        }

        [Fact]
        public void DrawFigureInsideCanvasShouldBeValid()
        {
            var canvas = new Rectangle(0, 0, 10, 10);
            var line = new Rectangle(0, 0, 5, 5);
            var canBeDrawn = drawingValidator.CanFigureBeDrawnInsideCanvas(canvas, line);
            Assert.True(canBeDrawn);
        }
    }
}
