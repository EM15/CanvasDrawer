using CanvasDrawer.Commands;
using CanvasDrawer.Exceptions;
using System;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class RectangleTests
    {
        [Fact]
        public void CreateWithValidCommandShouldBeDoneCorrectly()
        {
            var command = "R 10 20 30 40";
            var rectangle = new RectangleCommand(command);

            Assert.Equal(command, rectangle.CommandText);
            Assert.Equal(10, rectangle.X1);
            Assert.Equal(20, rectangle.Y1);
            Assert.Equal(30, rectangle.X2);
            Assert.Equal(40, rectangle.Y2);
            Assert.Equal(10, rectangle.DrawingValue.X);
            Assert.Equal(20, rectangle.DrawingValue.Y);
            Assert.Equal(20, rectangle.DrawingValue.Width);
            Assert.Equal(20, rectangle.DrawingValue.Height);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("R")]
        [InlineData("R 10")]
        [InlineData("R 10 20")]
        [InlineData("R 10 20 30")]
        [InlineData("R -10 20 30 40")]
        [InlineData("R 10 -20 30 40")]
        [InlineData("R 10 20 -30 40")]
        [InlineData("R 10 20 30 -40")]
        [InlineData("aR 10 20 30 40")]
        [InlineData("R 10 20 30 40a")]
        public void CreateWithInvalidCommandsShouldThrowAnArgumentException(string command)
        {
            Assert.Throws<InvalidCommandException>(() => new RectangleCommand(command));
        }

        [Theory]
        [InlineData("R 10 20 20 10")] // From bottom left to top right
        [InlineData("R 20 20 10 10")] // From bottom right to top left
        [InlineData("R 20 10 10 20")] // From top right to bottom left
        [InlineData("R 20 10 20 20")] // This is a vertical line
        [InlineData("R 20 10 30 10")] // This is a horizontal line
        public void CreateWithInvalidParametersShouldThrowAnArgumentException(string command)
        {
            Assert.Throws<ArgumentException>(() => new RectangleCommand(command));
        }

        [Fact]
        public void CanBeDrawnInsideCanvasShouldReturnOkIfItFits()
        {
            var canvas = new CanvasCommand(20, 20);
            var rectangle = new RectangleCommand("R 5 5 15 15");

            var canBeDrawnInsideCanvas = rectangle.CanBeDrawnInsideCanvas(canvas);
            Assert.True(canBeDrawnInsideCanvas);
        }

        [Fact]
        public void CanBeDrawnInsideCanvasShouldReturnOkIfItDoesNotFit()
        {
            var canvas = new CanvasCommand(20, 20);
            var rectangle = new RectangleCommand("R 5 5 25 25");

            var canBeDrawnInsideCanvas = rectangle.CanBeDrawnInsideCanvas(canvas);
            Assert.False(canBeDrawnInsideCanvas);
        }
    }
}
