using CanvasDrawer;
using CanvasDrawer.Console;
using CanvasDrawer.Creators;
using CanvasDrawer.Drawing;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ICommandCreator, CommandCreator>()
    .AddSingleton<IDrawer, Drawer>()
    .AddSingleton<IConsoleWriter, ConsoleWriter>()
    .AddSingleton<IConsoleReader, ConsoleReader>()
    .AddSingleton<ProgramExecutor>()
    .BuildServiceProvider();


Console.WriteLine(@"Only the following commands are allow:

Command 		Description
C w h           Should create a new canvas of width w and height h.
L x1 y1 x2 y2   Should create a new line from (x1,y1) to (x2,y2). Currently only
                horizontal or vertical lines are supported. Horizontal and vertical lines
                will be drawn using the 'x' character.
R x1 y1 x2 y2   Should create a new rectangle, whose upper left corner is (x1,y1) and
                lower right corner is (x2,y2). Horizontal and vertical lines will be drawn
                using the 'x' character.
B x y c         Should fill the entire area connected to (x,y) with 'colour' c. The
                behavior of this is the same as that of the 'bucket fill' tool in paint
                programs.
Q               Should quit the program.

");

var programExecutor = serviceProvider.GetService<ProgramExecutor>()!;
programExecutor.Execute();