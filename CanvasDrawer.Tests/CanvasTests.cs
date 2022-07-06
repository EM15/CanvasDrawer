using CanvasDrawer.Drawings;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class CanvasTests
    {
        [Fact]
        public void CanvasWidthHeightShouldBeSetCorrectly()
        {
            var command = "C 20 30";
            var canvas = new Canvas(command);
            Assert.True(canvas.Width == 20);
            Assert.True(canvas.Height == 30);
        }
    }
}
