using CanvasDrawer.Commands;
using CanvasDrawer.Exceptions;
using System;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class BucketFillTests
    {
        [Fact]
        public void CreateWithValidCommandShouldBeDoneCorrectly()
        {
            var command = "B 10 20 c";
            var bucketFill = new BucketFillCommand(command);

            Assert.Equal(command, bucketFill.CommandText);
            Assert.Equal(10, bucketFill.X);
            Assert.Equal(20, bucketFill.Y);
            Assert.Equal(10, bucketFill.DrawingValue.X);
            Assert.Equal(20, bucketFill.DrawingValue.Y);
            Assert.Equal('c', bucketFill.Color);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("B")]
        [InlineData("B 10")]
        [InlineData("B -10 20 c")]
        [InlineData("B 10 -20 c")]
        [InlineData("B 10 20 1")]
        [InlineData("B 10 20 +")]
        [InlineData("aB 10 20 ca")]
        public void CreateWithInvalidCommandsShouldThrowAnInvalidCommandException(string command)
        {
            Assert.Throws<InvalidCommandException>(() => new BucketFillCommand(command));
        }

        [Theory]
        [InlineData("B 1 1 c")]
        [InlineData("B 1 4 c")]
        [InlineData("B 4 1 c")]
        [InlineData("B 4 4 c")]
        public void CanBeDrawnInTheBordersShouldReturnOk(string command)
        {
            var canvas = new CanvasCommand(4, 4);
            var bucketFill = new BucketFillCommand(command);

            var canBeDrawnInsideCanvas = bucketFill.CanBeDrawnInsideCanvas(canvas);
            Assert.True(canBeDrawnInsideCanvas);
        }

        [Theory]
        [InlineData("B 0 0 c")]
        [InlineData("B 0 5 c")]
        [InlineData("B 5 0 c")]
        [InlineData("B 5 5 c")]
        [InlineData("B 1 5 c")]
        [InlineData("B 5 1 c")]
        public void CantBeDrawnOutsideTheBorderShouldReturnFalse(string command)
        {
            var canvas = new CanvasCommand(4, 4);
            var bucketFill = new BucketFillCommand(command);

            var canBeDrawnInsideCanvas = bucketFill.CanBeDrawnInsideCanvas(canvas);
            Assert.False(canBeDrawnInsideCanvas);
        }
    }
}
