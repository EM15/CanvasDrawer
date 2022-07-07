using CanvasDrawer.Console;
using CanvasDrawer.Creators;
using CanvasDrawer.Drawing;
using CanvasDrawer.Validators;
using FakeItEasy;

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
        private readonly Executor executor;

        public ExecutorTests()
        {
            fakeCommandValidator = A.Fake<ICommandValidator>();
            fakeFigureCreator = A.Fake<IFigureCreator>();
            fakeDrawingValidator = A.Fake<IDrawingValidator>();
            fakeDrawer = A.Fake<IDrawer>();
            fakeConsoleReader = A.Fake<IConsoleReader>();
            fakeConsoleWriter = A.Fake<IConsoleWriter>();
            executor = new Executor(fakeCommandValidator, fakeFigureCreator, fakeDrawingValidator, fakeDrawer, fakeConsoleReader, fakeConsoleWriter);
        }


    }
}
