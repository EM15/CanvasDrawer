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
    }
}