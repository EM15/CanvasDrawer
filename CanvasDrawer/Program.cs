using CanvasDrawer;
using CanvasDrawer.Console;
using CanvasDrawer.Creators;
using CanvasDrawer.Drawing;
using CanvasDrawer.Validators;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ICommandValidator, CommandValidator>()
    .AddSingleton<IFigureCreator, FigureCreator>()
    .AddSingleton<IDrawingValidator, DrawingValidator>()
    .AddSingleton<IDrawer, Drawer>()
    .AddSingleton<IConsoleWriter, ConsoleWriter>()
    .AddSingleton<IConsoleReader, ConsoleReader>()
    .AddSingleton<Executor>()
    .BuildServiceProvider();

var executor = serviceProvider.GetService<Executor>()!;
executor.ReadCanvasCommand();
executor.ReadDrawingCommands();