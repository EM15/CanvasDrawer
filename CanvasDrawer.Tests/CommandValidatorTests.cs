using CanvasDrawer.Validators;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class CommandValidatorTests
    {
        private readonly CommandValidator commandValidator = new CommandValidator();

        [Fact]
        public void EmptyCommandShouldNotBeValid()
        {
            var command = string.Empty;
            var isValid = commandValidator.IsCommandValid(command);
            Assert.False(isValid);
        }

        [Fact]
        public void NullCommandShouldNotBeValid()
        {
            string? command = null;
            var isValid = commandValidator.IsCommandValid(command);
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("C 20")]
        [InlineData("C  30")]
        [InlineData("A")]
        [InlineData("aC 20 30")]
        [InlineData("C -20 30")]
        [InlineData("A 20 30")]
        [InlineData("L 20")]
        [InlineData("L 20 30")]
        [InlineData("L 20 30 40")]
        [InlineData("L 20 30 40 -50")]
        [InlineData("aL 20 30 40 50 c")]
        [InlineData("R 20")]
        [InlineData("R 20 30")]
        [InlineData("R 20 30 10")]
        [InlineData("R 20 30 10 -50")]
        [InlineData("aR 20 30 10 50 c")]
        [InlineData("B 20")]
        [InlineData("B 20 30")]
        [InlineData("B 20 30 -")]
        [InlineData("aB 20 30 cc")]
        public void IncorrectCommandsShouldNotBeValid(string command)
        {
            var isValid = commandValidator.IsCommandValid(command);
            Assert.False(isValid);
        }

        [Fact]
        public void CorrectCanvasCommandShouldBeValid()
        {
            var command = "C 20 30";
            var isValid = commandValidator.IsCommandValid(command);
            Assert.True(isValid);
        }

        [Fact]
        public void CorrectLineCommandShouldBeValid()
        {
            var command = "L 20 30 40 50";
            var isValid = commandValidator.IsCommandValid(command);
            Assert.True(isValid);
        }

        [Fact]
        public void CorrectRectangleCommandShouldBeValid()
        {
            var command = "R 10 20 30 40";
            var isValid = commandValidator.IsCommandValid(command);
            Assert.True(isValid);
        }

        [Fact]
        public void CorrectBucketFillCommandShouldBeValid()
        {
            var command = "B 20 30 c";
            var isValid = commandValidator.IsCommandValid(command);
            Assert.True(isValid);
        }
    }
}