using CanvasDrawer.Commands;
using CanvasDrawer.Console;
using CanvasDrawer.Creators;
using CanvasDrawer.Drawing;
using FakeItEasy;
using System;
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
        private const string quitCommand = "Q";

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
            A.CallTo(() => fakeConsoleReader.ReadLine()).Returns(quitCommand);

            programExecutor.Execute();

            A.CallTo(() => fakeCommandCreator.CreateCommand(A<string>._)).MustNotHaveHappened();
            A.CallTo(() => fakeDrawer.Draw(A<Command>._)).MustNotHaveHappened();
        }

        [Fact]
        public void InsertNotQuitCommandShouldCreateCommandAndDraw()
        {
            var command = "Some valid command";
            A.CallTo(() => fakeConsoleReader.ReadLine())
                .ReturnsNextFromSequence(command, quitCommand);

            programExecutor.Execute();

            A.CallTo(() => fakeCommandCreator.CreateCommand(A<string>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => fakeDrawer.Draw(A<Command>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void CreateCommandThrowingExceptionShouldShowTheExceptionMessage()
        {
            var command = "Some invalid command";
            var exception = new Exception("Error");
            A.CallTo(() => fakeConsoleReader.ReadLine())
                .ReturnsNextFromSequence(command, quitCommand);
            A.CallTo(() => fakeCommandCreator.CreateCommand(A<string>.Ignored)).Throws(exception);

            programExecutor.Execute();
            A.CallTo(() => fakeDrawer.Draw(A<Command>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => fakeConsoleWriter.WriteLine(exception.Message)).MustHaveHappened();
        }

        [Fact]
        public void DrawThrowingExceptionShouldShowTheExceptionMessage()
        {
            var command = "Some invalid command";
            var exception = new Exception("Error");
            A.CallTo(() => fakeConsoleReader.ReadLine())
                .ReturnsNextFromSequence(command, quitCommand);
            A.CallTo(() => fakeDrawer.Draw(A<Command>.Ignored)).Throws(exception);

            programExecutor.Execute();
            A.CallTo(() => fakeConsoleWriter.WriteLine(exception.Message)).MustHaveHappened();
        }
    }
}
