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

        [Fact]
        public void CanBeDrawInsideCanvasShouldReturnOkIfItFits()
        {
            var canvas = new CanvasCommand(20, 20);
            var bucketFill = new BucketFillCommand("B 1 1 c");

            var canBeDrawInsideCanvas = bucketFill.CanBeDrawInsideCanvas(canvas);
            Assert.True(canBeDrawInsideCanvas);
        }

        [Fact]
        public void CanBeDrawInsideCanvasShouldReturnOkIfItDoesNotFit()
        {
            var canvas = new CanvasCommand(20, 20);
            var bucketFill = new BucketFillCommand("B 25 25 c");

            var canBeDrawInsideCanvas = bucketFill.CanBeDrawInsideCanvas(canvas);
            Assert.False(canBeDrawInsideCanvas);
        }
    }
}
