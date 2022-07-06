using Xunit;

namespace CanvasDrawer.Tests
{
    public class CommandValidatorTests
    {
        private readonly CommandValidator commandValidator = new CommandValidator();

        [Fact]
        public void CommandShouldBeValid()
        {
            var command = "C 20 30";
            var isValid = commandValidator.IsCanvasCommandValid(command);
            Assert.True(isValid);
        }
    }
}