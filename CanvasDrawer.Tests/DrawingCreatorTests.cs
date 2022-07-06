using CanvasDrawer.Creators;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class DrawingCreatorTests
    {
        private readonly DrawingCreator drawingCreator = new DrawingCreator();

        [Fact]
        public void CanvasWidthHeightShouldBeSetCorrectly()
        {
            var command = "C 20 30";
            var canvas = drawingCreator.CreateCanvas(command);
            Assert.True(canvas.Width == 20);
            Assert.True(canvas.Height == 30);
        }
    }
}
