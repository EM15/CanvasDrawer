using CanvasDrawer.Console;
using CanvasDrawer.Drawing;
using CanvasDrawer.Models;
using FakeItEasy;
using System;
using System.Text;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class DrawerTests
    {
        private readonly Drawer drawer;
        private readonly IConsoleWriter fakeConsoleWriter;

        public DrawerTests()
        {
            fakeConsoleWriter = A.Fake<IConsoleWriter>();
            drawer = new Drawer(fakeConsoleWriter);
        }

        [Fact]
        public void CanvasShouldBeDrawnCorrectly()
        {
            var canvas = new Canvas(4, 4);
            var canvasDrawSb = new StringBuilder();
            canvasDrawSb.AppendLine("------");
            canvasDrawSb.AppendLine("|    |");
            canvasDrawSb.AppendLine("|    |");
            canvasDrawSb.AppendLine("|    |");
            canvasDrawSb.AppendLine("|    |");
            canvasDrawSb.AppendLine("------");
            drawer.Draw(canvas);

            A.CallTo(() => fakeConsoleWriter.Write(canvasDrawSb.ToString())).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void DrawLineShouldThrowAnExceptionIfCanvasWasNotInitialized()
        {
            var line = new Line(10, 10, 10, 20);
            Assert.Throws<InvalidOperationException>(() => drawer.Draw(line));
        }

        [Fact]
        public void DrawRectangleShouldThrowAnExceptionIfCanvasWasNotInitialized()
        {
            var rectangle = new Rectangle(10, 10, 20, 20);
            Assert.Throws<InvalidOperationException>(() => drawer.Draw(rectangle));
        }

        [Fact]
        public void DrawBucketFillShouldThrowAnExceptionIfCanvasWasNotInitialized()
        {
            var bucketFill = new Line(10, 10, 10, 20);
            Assert.Throws<InvalidOperationException>(() => drawer.Draw(bucketFill));
        }

        [Fact]
        public void DrawRectangleShouldBeDrawnCorretly()
        {
            var canvas = new Canvas(4, 4);
            drawer.Draw(canvas);
            Fake.ClearRecordedCalls(fakeConsoleWriter);

            var rectangle = new Rectangle(1, 1, 3, 3);
            var outputSb = new StringBuilder();
            outputSb.AppendLine("------");
            outputSb.AppendLine("|xxx |");
            outputSb.AppendLine("|x x |");
            outputSb.AppendLine("|xxx |");
            outputSb.AppendLine("|    |");
            outputSb.AppendLine("------");

            drawer.Draw(rectangle);
            A.CallTo(() => fakeConsoleWriter.Write(outputSb.ToString())).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void DrawLineShouldBeDrawnCorretly()
        {
            var canvas = new Canvas(4, 4);
            drawer.Draw(canvas);
            Fake.ClearRecordedCalls(fakeConsoleWriter);

            var line = new Line(1, 1, 3, 1);
            var outputSb = new StringBuilder();
            outputSb.AppendLine("------");
            outputSb.AppendLine("|xxx |");
            outputSb.AppendLine("|    |");
            outputSb.AppendLine("|    |");
            outputSb.AppendLine("|    |");
            outputSb.AppendLine("------");

            drawer.Draw(line);
            A.CallTo(() => fakeConsoleWriter.Write(outputSb.ToString())).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void DrawBucketFillShouldBeDrawnCorrectly()
        {
            var canvas = new Canvas(4, 4);
            drawer.Draw(canvas);

            var rectangle = new Rectangle(1, 2, 3, 4);
            drawer.Draw(rectangle);

            Fake.ClearRecordedCalls(fakeConsoleWriter);

            var bucketFill = new BucketFill(1, 1, 'c');

            var outputSb = new StringBuilder();
            outputSb.AppendLine("------");
            outputSb.AppendLine("|cccc|");
            outputSb.AppendLine("|xxxc|");
            outputSb.AppendLine("|x xc|");
            outputSb.AppendLine("|xxxc|");
            outputSb.AppendLine("------");

            drawer.Draw(bucketFill);
            A.CallTo(() => fakeConsoleWriter.Write(outputSb.ToString())).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void BucketFillShouldBeAppliedToAnotherColorCorrectly()
        {
            var canvas = new Canvas(4, 4);
            drawer.Draw(canvas);

            var rectangle = new Rectangle(1, 2, 3, 4);
            drawer.Draw(rectangle);
            Fake.ClearRecordedCalls(fakeConsoleWriter);

            var bucketFill = new BucketFill(1, 2, 'c');

            var outputSb = new StringBuilder();
            outputSb.AppendLine("------");
            outputSb.AppendLine("|    |");
            outputSb.AppendLine("|ccc |");
            outputSb.AppendLine("|c c |");
            outputSb.AppendLine("|ccc |");
            outputSb.AppendLine("------");

            drawer.Draw(bucketFill);
            A.CallTo(() => fakeConsoleWriter.Write(outputSb.ToString())).MustHaveHappenedOnceExactly();
        }
    }
}
