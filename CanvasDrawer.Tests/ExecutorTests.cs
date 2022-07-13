using CanvasDrawer.Console;
using CanvasDrawer.Creators;
using CanvasDrawer.Drawing;
using CanvasDrawer.Validators;
using FakeItEasy;
using System.Drawing;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class ExecutorTests
    {
        private readonly ICommandValidator fakeCommandValidator;
        private readonly IFigureCreator fakeFigureCreator;
        private readonly IDrawingValidator fakeDrawingValidator;
        private readonly IDrawer fakeDrawer;
        private readonly IConsoleReader fakeConsoleReader;
        private readonly IConsoleWriter fakeConsoleWriter;
        private readonly IEnvironment fakeEnvironment;
        private readonly ProgramExecutor executor;
        private const string InvalidCommandMessage = "Invalid command";
        private const string exitCommand = "Q";

        public ExecutorTests()
        {
            fakeCommandValidator = A.Fake<ICommandValidator>();
            fakeFigureCreator = A.Fake<IFigureCreator>();
            fakeDrawingValidator = A.Fake<IDrawingValidator>();
            fakeDrawer = A.Fake<IDrawer>();
            fakeConsoleReader = A.Fake<IConsoleReader>();
            fakeConsoleWriter = A.Fake<IConsoleWriter>();
            fakeEnvironment = A.Fake<IEnvironment>();
            executor = new Executor(fakeCommandValidator, fakeFigureCreator, fakeDrawingValidator, fakeDrawer, fakeConsoleReader, fakeConsoleWriter, fakeEnvironment);
        }

        [Fact]
        public void ReadCanvasCommandShouldExitWhenExitCommandIsRead()
        {
            A.CallTo(() => fakeConsoleReader.ReadLine()).Returns(exitCommand);

            executor.ReadCanvasCommand();

            A.CallTo(() => fakeEnvironment.ExitProgram())
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void ReadCanvasCommandShouldShowErrorMessageIfCommandIsInvalid()
        {
            A.CallTo(() => fakeCommandValidator.IsCanvasCommandValid(A<string>.Ignored))
                .ReturnsNextFromSequence(false, true);

            executor.ReadCanvasCommand();

            A.CallTo(() => fakeConsoleWriter.WriteLine(InvalidCommandMessage))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void ReadCanvasCommandShouldBeReadUntilItIntroducesAValidCommand()
        {
            A.CallTo(() => fakeCommandValidator.IsCanvasCommandValid(A<string>.Ignored))
                .ReturnsNextFromSequence(false, false, true);

            executor.ReadCanvasCommand();

            A.CallTo(() => fakeConsoleReader.ReadLine())
                .MustHaveHappened(3, Times.Exactly);
        }

        [Fact]
        public void ReadCanvasCommandShouldCreateItAndDrawIt()
        {
            A.CallTo(() => fakeCommandValidator.IsCanvasCommandValid(A<string>._))
                .Returns(true);

            executor.ReadCanvasCommand();

            A.CallTo(() => fakeFigureCreator.CreateCanvas(A<string>._)).MustHaveHappenedOnceExactly()
                .Then(A.CallTo(() => fakeDrawer.DrawCanvas(A<Rectangle>._)).MustHaveHappenedOnceExactly());
        }

        [Fact]
        public void ReadDrawingCommandShouldExitWhenExitCommandIsRead()
        {
            A.CallTo(() => fakeConsoleReader.ReadLine()).Returns(exitCommand);

            A.CallTo(() => fakeConsoleReader.ReadLine()).Returns(exitCommand);

            executor.ReadDrawingCommands();

            A.CallTo(() => fakeEnvironment.ExitProgram())
                .MustHaveHappenedOnceExactly();
        }
        private void CreateCanvas()
        {
            A.CallTo(() => fakeCommandValidator.IsCanvasCommandValid(A<string>.Ignored))
                .ReturnsNextFromSequence(true);
            A.CallTo(() => fakeFigureCreator.CreateCanvas(A<string>._)).Returns(new Rectangle(1, 1, 10, 10));
            executor.ReadCanvasCommand();
            Fake.ClearRecordedCalls(fakeConsoleWriter);
        }

        [Fact]
        public void ReadDrawingCommandShouldShowErrorMessageIfCommandIsInvalid()
        {
            CreateCanvas();

            A.CallTo(() => fakeCommandValidator.IsDrawingCommandValid(A<string>.Ignored))
                .ReturnsNextFromSequence(false, true);
            A.CallTo(() => fakeDrawingValidator.CanFigureBeDrawnInsideCanvas(A<Rectangle>._, A<Rectangle>._)).Returns(true);

            A.CallTo(() => fakeConsoleReader.ReadLine()).ReturnsNextFromSequence("Some command", "Q");

            executor.ReadDrawingCommands();

            A.CallTo(() => fakeConsoleWriter.WriteLine(InvalidCommandMessage))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void ReadDrawingCommandShouldCreateBuckedFillWhenCommandIsValid()
        {
            CreateCanvas();

            A.CallTo(() => fakeCommandValidator.IsDrawingCommandValid(A<string>.Ignored))
                .Returns(true);
            A.CallTo(() => fakeDrawingValidator.IsBucketFillPointInsideCanvas(A<Rectangle>._, A<Point>._)).Returns(true);

            A.CallTo(() => fakeConsoleReader.ReadLine()).ReturnsNextFromSequence("B 1 1 c", "Q");

            executor.ReadDrawingCommands();

            A.CallTo(() => fakeFigureCreator.CreateBucketFill(A<string>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => fakeDrawer.ApplyBucketFill(A<Point>._, A<char>._))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void ReadDrawingCommandShouldCreateFigureFillWhenCommandIsValid()
        {
            CreateCanvas();

            A.CallTo(() => fakeCommandValidator.IsDrawingCommandValid(A<string>.Ignored))
                .Returns(true);
            A.CallTo(() => fakeDrawingValidator.CanFigureBeDrawnInsideCanvas(A<Rectangle>._, A<Rectangle>._)).Returns(true);

            A.CallTo(() => fakeConsoleReader.ReadLine()).ReturnsNextFromSequence("R 2 3 4 5", "Q");

            executor.ReadDrawingCommands();

            A.CallTo(() => fakeFigureCreator.CreateFigure(A<string>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => fakeDrawer.Draw(A<Rectangle>._))
                .MustHaveHappenedOnceExactly();
        }
    }
}
