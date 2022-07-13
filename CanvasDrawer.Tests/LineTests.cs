using CanvasDrawer.Models;
using System;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class LineTests
    {
        [Fact]
        public void CreateWithValidCommandShouldBeDoneCorrectly()
        {
            var command = "L 10 20 10 30";
            var line = new Line(command);

            Assert.Equal(command, line.CommandText);
            Assert.Equal(10, line.X1);
            Assert.Equal(20, line.Y1);
            Assert.Equal(10, line.X2);
            Assert.Equal(30, line.Y2);
            Assert.Equal(10, line.DrawingValue.X);
            Assert.Equal(20, line.DrawingValue.Y);
            Assert.Equal(0, line.DrawingValue.Width);
            Assert.Equal(10, line.DrawingValue.Height);
        }

        [Fact]
        public void CreateWithCommandFromRightToLeftShouldBeDoneCorrectly()
        {
            var command = "L 20 20 10 20";
            var line = new Line(command);

            Assert.Equal(command, line.CommandText);
            Assert.Equal(20, line.X1);
            Assert.Equal(20, line.Y1);
            Assert.Equal(10, line.X2);
            Assert.Equal(20, line.Y2);
            Assert.Equal(10, line.DrawingValue.X);
            Assert.Equal(20, line.DrawingValue.Y);
            Assert.Equal(10, line.DrawingValue.Width);
            Assert.Equal(0, line.DrawingValue.Height);
        }

        [Fact]
        public void CreateWithCommandFromBottomToTopShouldBeDoneCorrectly()
        {
            var command = "L 10 20 10 10";
            var line = new Line(command);

            Assert.Equal(command, line.CommandText);
            Assert.Equal(10, line.X1);
            Assert.Equal(20, line.Y1);
            Assert.Equal(10, line.X2);
            Assert.Equal(10, line.Y2);
            Assert.Equal(10, line.DrawingValue.X);
            Assert.Equal(10, line.DrawingValue.Y);
            Assert.Equal(0, line.DrawingValue.Width);
            Assert.Equal(10, line.DrawingValue.Height);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("L")]
        [InlineData("L 10")]
        [InlineData("L 10 20")]
        [InlineData("L 10 20 10")]
        [InlineData("L 20 20 30 30")] // Diagonal line
        [InlineData("L -20 30 20 40")]
        [InlineData("L 20 -30 20 40")]
        [InlineData("L 20 30 -20 40")]
        [InlineData("L 20 30 20 -40")]
        [InlineData("aL 10 20 10 30")]
        [InlineData("L 10 20 10 30a")]
        public void CreateWithInvalidCommandsShouldThrowAnArgumentException(string command)
        {
            Assert.Throws<ArgumentException>(() => new Line(command));
        }

        [Fact]
        public void CanBeDrawInsideCanvasShouldReturnOkIfItFits()
        {
            var canvas = new Canvas("C 20 20");
            var line = new Line("L 5 5 5 15");

            var canBeDrawInsideCanvas = line.CanBeDrawInsideCanvas(canvas);
            Assert.True(canBeDrawInsideCanvas);
        }

        [Fact]
        public void CanBeDrawInsideCanvasShouldReturnOkIfItDoesNotFit()
        {
            var canvas = new Canvas("C 20 20");
            var line = new Line("L 5 5 5 25");

            var canBeDrawInsideCanvas = line.CanBeDrawInsideCanvas(canvas);
            Assert.False(canBeDrawInsideCanvas);
        }
    }
}
