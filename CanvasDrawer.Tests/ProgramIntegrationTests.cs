using CanvasDrawer.Console;
using CanvasDrawer.Creators;
using CanvasDrawer.Drawing;
using FakeItEasy;
using FakeItEasy.Configuration;
using System.Text;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class ProgramIntegrationTests
    {
        private readonly ProgramExecutor executor;
        private readonly IConsoleReader fakeConsoleReader;
        private readonly IConsoleWriter fakeConsoleWriter;
        private UnorderedCallAssertion InsertCommand => A.CallTo(() => fakeConsoleWriter.WriteLine("Please insert command")).MustHaveHappened();
        private UnorderedCallAssertion InvalidCommand => A.CallTo(() => fakeConsoleWriter.WriteLine("Invalid command")).MustHaveHappened();
        private UnorderedCallAssertion CanvasNotInitialized => A.CallTo(() => fakeConsoleWriter.WriteLine("Canvas was not initialized")).MustHaveHappened();
        private UnorderedCallAssertion CantDrawInsideCanvas => A.CallTo(() => fakeConsoleWriter.WriteLine("Command can't be applied to current canvas")).MustHaveHappened();
        private UnorderedCallAssertion Output(StringBuilder output) => A.CallTo(() => fakeConsoleWriter.Write(output.ToString())).MustHaveHappened();

        public ProgramIntegrationTests()
        {
            fakeConsoleWriter = A.Fake<IConsoleWriter>();
            fakeConsoleReader = A.Fake<IConsoleReader>();
            executor = new ProgramExecutor(new CommandCreator(), new Drawer(fakeConsoleWriter), fakeConsoleReader, fakeConsoleWriter);
        }

        [Fact]
        public void OutputShouldBeTheOneExpected1()
        {
            A.CallTo(() => fakeConsoleReader.ReadLine())
                .ReturnsNextFromSequence("C 20 4", "A", "L 1 2 6 2", "Z", "L 6 3 6 4", "R 14 1 18 3", "B 10 3 o", "Q");

            var output1 = new StringBuilder();
            output1.AppendLine("----------------------");
            output1.AppendLine("|                    |");
            output1.AppendLine("|                    |");
            output1.AppendLine("|                    |");
            output1.AppendLine("|                    |");
            output1.AppendLine("----------------------");

            var output2 = new StringBuilder();
            output2.AppendLine("----------------------");
            output2.AppendLine("|                    |");
            output2.AppendLine("|xxxxxx              |");
            output2.AppendLine("|                    |");
            output2.AppendLine("|                    |");
            output2.AppendLine("----------------------");

            var output3 = new StringBuilder();
            output3.AppendLine("----------------------");
            output3.AppendLine("|                    |");
            output3.AppendLine("|xxxxxx              |");
            output3.AppendLine("|     x              |");
            output3.AppendLine("|     x              |");
            output3.AppendLine("----------------------");

            var output4 = new StringBuilder();
            output4.AppendLine("----------------------");
            output4.AppendLine("|             xxxxx  |");
            output4.AppendLine("|xxxxxx       x   x  |");
            output4.AppendLine("|     x       xxxxx  |");
            output4.AppendLine("|     x              |");
            output4.AppendLine("----------------------");

            var output5 = new StringBuilder();
            output5.AppendLine("----------------------");
            output5.AppendLine("|oooooooooooooxxxxxoo|");
            output5.AppendLine("|xxxxxxooooooox   xoo|");
            output5.AppendLine("|     xoooooooxxxxxoo|");
            output5.AppendLine("|     xoooooooooooooo|");
            output5.AppendLine("----------------------");

            executor.Execute();

            InsertCommand
                .Then(Output(output1))
                .Then(InsertCommand)
                .Then(InvalidCommand)
                .Then(InsertCommand)
                .Then(Output(output2))
                .Then(InsertCommand)
                .Then(InvalidCommand)
                .Then(InsertCommand)
                .Then(Output(output3))
                .Then(Output(output4))
                .Then(Output(output5));
        }

        [Fact]
        public void OutputShouldBeTheOneExpected2()
        {
            A.CallTo(() => fakeConsoleReader.ReadLine())
                .ReturnsNextFromSequence("R 1 1 2 2", "L 1 1 2 1", "B 1 1 c", "C 4 4", "R 1 1 5 5", "L 1 1 6 1", "B 5 5 c", "Q");

            var output1 = new StringBuilder();
            output1.AppendLine("------");
            output1.AppendLine("|    |");
            output1.AppendLine("|    |");
            output1.AppendLine("|    |");
            output1.AppendLine("|    |");
            output1.AppendLine("------");

            executor.Execute();

            InsertCommand
                .Then(CanvasNotInitialized)
                .Then(InsertCommand)
                .Then(CanvasNotInitialized)
                .Then(InsertCommand)
                .Then(CanvasNotInitialized)
                .Then(InsertCommand)
                .Then(Output(output1))
                .Then(InsertCommand)
                .Then(CantDrawInsideCanvas)
                .Then(InsertCommand)
                .Then(CantDrawInsideCanvas)
                .Then(InsertCommand)
                .Then(CantDrawInsideCanvas)
                .Then(InsertCommand);
        }

        [Fact]
        public void OutputShouldBeTheOneExpected3()
        {
            A.CallTo(() => fakeConsoleReader.ReadLine())
                .ReturnsNextFromSequence("C 4 4", "L 1 2 1 4", "L 2 3 4 3", "B 1 1 Z", "C 5 5", "L 1 1 4 1", "Q");

            var output1 = new StringBuilder();
            output1.AppendLine("------");
            output1.AppendLine("|    |");
            output1.AppendLine("|    |");
            output1.AppendLine("|    |");
            output1.AppendLine("|    |");
            output1.AppendLine("------");

            var output2 = new StringBuilder();
            output2.AppendLine("------");
            output2.AppendLine("|    |");
            output2.AppendLine("|x   |");
            output2.AppendLine("|x   |");
            output2.AppendLine("|x   |");
            output2.AppendLine("------");

            var output3 = new StringBuilder();
            output3.AppendLine("------");
            output3.AppendLine("|    |");
            output3.AppendLine("|x   |");
            output3.AppendLine("|xxxx|");
            output3.AppendLine("|x   |");
            output3.AppendLine("------");

            executor.Execute();

            InsertCommand
                .Then(CanvasNotInitialized)
                .Then(InsertCommand)
                .Then(CanvasNotInitialized)
                .Then(InsertCommand)
                .Then(CanvasNotInitialized)
                .Then(InsertCommand)
                .Then(Output(output1))
                .Then(InsertCommand)
                .Then(CantDrawInsideCanvas)
                .Then(InsertCommand)
                .Then(CantDrawInsideCanvas)
                .Then(InsertCommand)
                .Then(CantDrawInsideCanvas)
                .Then(InsertCommand);
        }
    }
}
