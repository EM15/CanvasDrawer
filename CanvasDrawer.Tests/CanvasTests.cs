using CanvasDrawer.Models;
using System;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class CanvasTests
    {
        [Fact]
        public void CreateWithValidCommandShouldBeDoneCorrectly()
        {
            var command = "C 20 30";
            var canvas = new Canvas(command);

            Assert.Equal(command, canvas.CommandText);
            Assert.Equal(20, canvas.Width);
            Assert.Equal(30, canvas.Height);
            Assert.Equal(1, canvas.DrawingValue.X);
            Assert.Equal(1, canvas.DrawingValue.Y);
            Assert.Equal(20, canvas.DrawingValue.Width);
            Assert.Equal(30, canvas.DrawingValue.Height);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("C")]
        [InlineData("C 30")]
        [InlineData("C 0 30")]
        [InlineData("C 30 0")]
        [InlineData("C -20 30")]
        [InlineData("C 20 -30")]
        [InlineData("C 20 30a")]
        [InlineData("aC 20 30")]
        public void CreateWithInvalidCommandsShouldThrowAnArgumentException(string command)
        {
            Assert.Throws<ArgumentException>(() => new Canvas(command));
        }
    }
}
