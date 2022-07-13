using CanvasDrawer.Console;
using CanvasDrawer.Drawing;
using FakeItEasy;
using System;
using System.Drawing;
using System.Text;
using Xunit;

namespace CanvasDrawer.Tests
{
    public class DrawerTests
    {
        //private readonly Drawer drawer;
        //private readonly IConsoleWriter fakeConsoleWriter;

        //public DrawerTests()
        //{
        //    fakeConsoleWriter = A.Fake<IConsoleWriter>();
        //    drawer = new Drawer(fakeConsoleWriter);
        //}

        //[Fact]
        //public void CanvasShouldBeDrawnCorrectly()
        //{
        //    var canvas = new Rectangle(1, 1, 4, 4);
        //    var canvasDrawSb = new StringBuilder();
        //    canvasDrawSb.AppendLine("------");
        //    canvasDrawSb.AppendLine("|    |");
        //    canvasDrawSb.AppendLine("|    |");
        //    canvasDrawSb.AppendLine("|    |");
        //    canvasDrawSb.AppendLine("|    |");
        //    canvasDrawSb.AppendLine("------");
        //    drawer.DrawCanvas(canvas);

        //    A.CallTo(() => fakeConsoleWriter.Write(canvasDrawSb.ToString())).MustHaveHappenedOnceExactly();
        //}

        //[Fact]
        //public void DrawFigureShouldThrowAnExceptionIfCanvasWasNotInitialized()
        //{
        //    var figure = new Rectangle(1, 1, 4, 4);
        //    Assert.Throws<InvalidOperationException>(() => drawer.Draw(figure));
        //}

        //[Fact]
        //public void ApplyBucketFillShouldThrowAnExceptionIfCanvasWasNotInitialized()
        //{
        //    var point = new Point(1, 1);
        //    var color = 'c';
        //    Assert.Throws<InvalidOperationException>(() => drawer.ApplyBucketFill(point, color));
        //}

        //[Fact]
        //public void DrawFigureShouldBeDrawnCorretly()
        //{
        //    var canvas = new Rectangle(1, 1, 4, 4);
        //    drawer.DrawCanvas(canvas);
        //    Fake.ClearRecordedCalls(fakeConsoleWriter);

        //    var figure = new Rectangle(1, 1, 2, 2);
        //    var outputSb = new StringBuilder();
        //    outputSb.AppendLine("------");
        //    outputSb.AppendLine("|xxx |");
        //    outputSb.AppendLine("|x x |");
        //    outputSb.AppendLine("|xxx |");
        //    outputSb.AppendLine("|    |");
        //    outputSb.AppendLine("------");

        //    drawer.Draw(figure);
        //    A.CallTo(() => fakeConsoleWriter.Write(outputSb.ToString())).MustHaveHappenedOnceExactly();
        //}

        //[Fact]
        //public void BucketFillShouldBeAppliedCorretly()
        //{
        //    var canvas = new Rectangle(1, 1, 4, 4);
        //    drawer.DrawCanvas(canvas);

        //    var figure = new Rectangle(1, 2, 2, 2);
        //    drawer.Draw(figure);
        //    Fake.ClearRecordedCalls(fakeConsoleWriter);

        //    var point = new Point(1, 1);
        //    var color = 'c';

        //    var outputSb = new StringBuilder();
        //    outputSb.AppendLine("------");
        //    outputSb.AppendLine("|cccc|");
        //    outputSb.AppendLine("|xxxc|");
        //    outputSb.AppendLine("|x xc|");
        //    outputSb.AppendLine("|xxxc|");
        //    outputSb.AppendLine("------");

        //    drawer.ApplyBucketFill(point, color);
        //    A.CallTo(() => fakeConsoleWriter.Write(outputSb.ToString())).MustHaveHappenedOnceExactly();
        //}

        //[Fact]
        //public void BucketFillToAFigureShouldBeAppliedCorretly()
        //{
        //    var canvas = new Rectangle(1, 1, 4, 4);
        //    drawer.DrawCanvas(canvas);

        //    var figure = new Rectangle(1, 2, 2, 2);
        //    drawer.Draw(figure);
        //    Fake.ClearRecordedCalls(fakeConsoleWriter);

        //    var point = new Point(1, 2);
        //    var color = 'c';

        //    var outputSb = new StringBuilder();
        //    outputSb.AppendLine("------");
        //    outputSb.AppendLine("|    |");
        //    outputSb.AppendLine("|ccc |");
        //    outputSb.AppendLine("|c c |");
        //    outputSb.AppendLine("|ccc |");
        //    outputSb.AppendLine("------");

        //    drawer.ApplyBucketFill(point, color);
        //    A.CallTo(() => fakeConsoleWriter.Write(outputSb.ToString())).MustHaveHappenedOnceExactly();
        //}
    }
}
