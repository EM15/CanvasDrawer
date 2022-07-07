using CanvasDrawer.Console;
using FakeItEasy;
using System;
using System.Drawing;
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
            var canvas = new Rectangle(1, 1, 4, 4);
            var canvasDrawSb = new StringBuilder();
            canvasDrawSb.AppendLine("------");
            canvasDrawSb.AppendLine("|    |");
            canvasDrawSb.AppendLine("|    |");
            canvasDrawSb.AppendLine("|    |");
            canvasDrawSb.AppendLine("|    |");
            canvasDrawSb.AppendLine("------");
            drawer.DrawCanvas(canvas);

            A.CallTo(() => fakeConsoleWriter.Write(canvasDrawSb.ToString())).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void DrawFigureShouldThrowAnExceptionIfCanvasWasNotInitialized()
        {
            var figure = new Rectangle(1, 1, 4, 4);
            Assert.Throws<InvalidOperationException>(() => drawer.Draw(figure));
        }

        [Fact]
        public void ApplyBucketFillShouldThrowAnExceptionIfCanvasWasNotInitialized()
        {
            var point = new Point(1, 1);
            var color = 'c';
            Assert.Throws<InvalidOperationException>(() => drawer.ApplyBucketFill(point, color));
        }
    }
}
