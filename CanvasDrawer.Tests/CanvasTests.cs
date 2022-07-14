using CanvasDrawer.Commands;
using CanvasDrawer.Exceptions;
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
            var canvas = new CanvasCommand(command);

            Assert.Equal(command, canvas.CommandText);
            Assert.Equal(20, canvas.Width);
            Assert.Equal(30, canvas.Height);
            Assert.Equal(1, canvas.DrawingValue.X);
            Assert.Equal(1, canvas.DrawingValue.Y);
            Assert.Equal(19, canvas.DrawingValue.Width);
            Assert.Equal(29, canvas.DrawingValue.Height);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("C")]
        [InlineData("C 30")]
        [InlineData("C -20 30")]
        [InlineData("C 20 -30")]
        [InlineData("C 20 30a")]
        [InlineData("aC 20 30")]
        public void CreateWithInvalidCommandsShouldThrowAnInvalidCommandException(string command)
        {
            Assert.Throws<InvalidCommandException>(() => new CanvasCommand(command));
        }

        [Theory]
        [InlineData("C 0 30")]
        [InlineData("C 30 0")]
        public void CreateWithInvalidParametersShouldThrowAnArgumentException(string command)
        {
            Assert.Throws<ArgumentException>(() => new CanvasCommand(command));
        }
    }
}
