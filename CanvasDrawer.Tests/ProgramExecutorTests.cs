using CanvasDrawer.Console;
using CanvasDrawer.Creators;
using CanvasDrawer.Drawing;
using CanvasDrawer.Models;
using FakeItEasy;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class ProgramExecutorTests
    {
        private readonly ProgramExecutor programExecutor;
        private readonly IDrawer fakeDrawer;
        private readonly ICommandCreator fakeCommandCreator;
        private readonly IConsoleReader fakeConsoleReader;
        private readonly IConsoleWriter fakeConsoleWriter;

        public ProgramExecutorTests()
        {
            fakeDrawer = A.Fake<IDrawer>();
            fakeCommandCreator = A.Fake<ICommandCreator>();
            fakeConsoleReader = A.Fake<IConsoleReader>();
            fakeConsoleWriter = A.Fake<IConsoleWriter>();
            programExecutor = new ProgramExecutor(fakeCommandCreator, fakeDrawer, fakeConsoleReader, fakeConsoleWriter);
        }

        [Fact]
        public void InsertQuitCommandShouldNotDoAnything()
        {
            var command = "Q";
            A.CallTo(() => fakeConsoleReader.ReadLine()).Returns(command);

            programExecutor.Execute();

            A.CallTo(() => fakeCommandCreator.CreateCommand(A<string>._)).MustNotHaveHappened();
            A.CallTo(() => fakeDrawer.Draw(A<Command>._)).MustNotHaveHappened();
        }

        // TODO: Add more tests
    }
}
