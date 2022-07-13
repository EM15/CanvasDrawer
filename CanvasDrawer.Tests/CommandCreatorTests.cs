using CanvasDrawer.Commands;
using CanvasDrawer.Creators;
using CanvasDrawer.Exceptions;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class CommandCreatorTests
    {
        private readonly CommandCreator commandCreator = new CommandCreator();

        [Fact]
        public void CanvasCommandShouldBeCreatedCorrectly()
        {
            var command = commandCreator.CreateCommand("C 20 4");
            Assert.IsType<CanvasCommand>(command);
        }

        [Fact]
        public void LineCommandShouldBeCreatedCorrectly()
        {
            var command = commandCreator.CreateCommand("L 1 2 6 2");
            Assert.IsType<LineCommand>(command);
        }

        [Fact]
        public void RectangleCommandShouldBeCreatedCorrectly()
        {
            var command = commandCreator.CreateCommand("R 14 1 18 3");
            Assert.IsType<RectangleCommand>(command);
        }

        [Fact]
        public void BucketFillCommandShouldBeCreatedCorrectly()
        {
            var command = commandCreator.CreateCommand("B 10 3 o");
            Assert.IsType<BucketFillCommand>(command);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Z")]
        public void InvalidCommandShouldThrowAnException(string command)
        {
            Assert.Throws<InvalidCommandException>(() => commandCreator.CreateCommand(command));
        }
    }
}
