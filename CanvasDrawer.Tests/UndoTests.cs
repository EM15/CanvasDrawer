using CanvasDrawer.Commands;
using CanvasDrawer.Exceptions;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class UndoTests
    {
        [Fact]
        public void CreateWithValidCommandShouldBeDoneCorrectly()
        {
            var command = "U";
            var canvas = new UndoCommand(command);

            Assert.Equal(command, canvas.CommandText);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" U")]
        [InlineData("U ")]
        [InlineData("1U")]
        [InlineData("U1")]
        [InlineData(" U ")]
        [InlineData("U 1")]
        public void CreateWithInvalidCommandsShouldThrowAnInvalidCommandException(string command)
        {
            Assert.Throws<InvalidCommandException>(() => new UndoCommand(command));
        }
    }
}
