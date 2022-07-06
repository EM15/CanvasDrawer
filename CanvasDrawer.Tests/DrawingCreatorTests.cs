using CanvasDrawer.Creators;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class DrawingCreatorTests
    {
        private readonly DrawingCreator drawingCreator = new DrawingCreator();

        [Fact]
        public void CanvasValuesShouldBeSetCorrectly()
        {
            var command = "C 20 30";
            var canvas = drawingCreator.CreateCanvas(command);
            Assert.True(canvas.Width == 20);
            Assert.True(canvas.Height == 30);
        }

        [Fact]
        public void LineValuesShouldBeSetCorrectly()
        {
            var command = "L 20 30 40 50";
            var line = drawingCreator.CreateLine(command);
            Assert.True(line.X1 == 20);
            Assert.True(line.Y1 == 30);
            Assert.True(line.X2 == 40);
            Assert.True(line.Y2 == 50);
        }

        [Fact]
        public void RectangleValuesShouldBeSetCorrectly()
        {
            var command = "R 20 30 40 50";
            var rectangle = drawingCreator.CreateRectangle(command);
            Assert.True(rectangle.X1 == 20);
            Assert.True(rectangle.Y1 == 30);
            Assert.True(rectangle.X2 == 40);
            Assert.True(rectangle.Y2 == 50);
        }
    }
}
