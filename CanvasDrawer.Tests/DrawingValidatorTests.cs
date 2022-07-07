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
            var line = new Rectangle(10, 10, 1, 1);
            var canBeDraw = drawingValidator.CanFigureBeDraw(canvas, new List<Rectangle>(), line);
            Assert.False(canBeDraw);
        }

        [Fact]
        public void DrawFigureThatGoesOutOfBoundsShouldBeInvalid()
        {
            var canvas = new Rectangle(0, 0, 10, 10);
            var line = new Rectangle(0, 0, 11, 11);
            var canBeDraw = drawingValidator.CanFigureBeDraw(canvas, new List<Rectangle>(), line);
            Assert.False(canBeDraw);
        }

        [Fact]
        public void DrawFigureInsideCanvasShouldBeValid()
        {
            var canvas = new Rectangle(0, 0, 10, 10);
            var line = new Rectangle(0, 0, 5, 5);
            var canBeDraw = drawingValidator.CanFigureBeDraw(canvas, new List<Rectangle>(), line);
            Assert.True(canBeDraw);
        }
    }
}
