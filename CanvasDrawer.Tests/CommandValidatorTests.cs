using Xunit;

namespace CanvasDrawer.Tests
{
    public class CommandValidatorTests
    {
        private readonly CommandValidator commandValidator = new CommandValidator();

        [Fact]
        public void EmptyCanvasCommandShouldNotBeValid()
        {
            var command = string.Empty;
            var isValid = commandValidator.IsCanvasCommandValid(command);
            Assert.False(isValid);
        }

        [Fact]
        public void NullCanvasCommandShouldNotBeValid()
        {
            string? command = null;
            var isValid = commandValidator.IsCanvasCommandValid(command);
            Assert.False(isValid);
        }

        [Fact]
        public void IncorrectCanvasCommandsShouldNotBeValid()
        {
            var commands = new[]
            {
                "C 20",
                "C  30",
                "A",
                "C 20 -30",
                "C -20 30",
                "A 20 30"
            };

            foreach (var command in commands)
            {
                var isValid = commandValidator.IsCanvasCommandValid(command);
                Assert.False(isValid);
            }
        }

        [Fact]
        public void CorrectCanvasCommandShouldBeValid()
        {
            var command = "C 20 30";
            var isValid = commandValidator.IsCanvasCommandValid(command);
            Assert.True(isValid);
        }

        [Fact]
        public void EmptyDrawingCommandShouldNotBeValid()
        {
            var command = string.Empty;
            var isValid = commandValidator.IsDrawingCommandValid(command);
            Assert.False(isValid);
        }

        [Fact]
        public void NullDrawingCommandShouldNotBeValid()
        {
            string? command = null;
            var isValid = commandValidator.IsDrawingCommandValid(command);
            Assert.False(isValid);
        }

        [Fact]
        public void IncorrectDrawingCommandsShouldNotBeValid()
        {
            var commands = new[]
            {
                "L 20",
                "L 20 30",
                "L 20 30 40",
                "L 20 30 40 -50",
                "R 20",
                "R 20 30",
                "R 20 30 10",
                "R 20 30 10 -50",
                "B 20",
                "B 20 30",
                "B 20 -30 c"
            };

            foreach (var command in commands)
            {
                var isValid = commandValidator.IsCanvasCommandValid(command);
                Assert.False(isValid);
            }
        }

        [Fact]
        public void CorrectDrawingLineCommandShouldBeValid()
        {
            var command = "L 20 30 40 50";
            var isValid = commandValidator.IsCanvasCommandValid(command);
            Assert.True(isValid);
        }

        [Fact]
        public void CorrectDrawingRectangleCommandShouldBeValid()
        {
            var command = "R 10 20 30 40";
            var isValid = commandValidator.IsCanvasCommandValid(command);
            Assert.True(isValid);
        }

        [Fact]
        public void CorrectDrawingColourCommandShouldBeValid()
        {
            var command = "B 20 30 c";
            var isValid = commandValidator.IsCanvasCommandValid(command);
            Assert.True(isValid);
        }
    }
}