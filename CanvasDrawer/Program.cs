using CanvasDrawer;
using CanvasDrawer.Console;
using CanvasDrawer.Creators;
using CanvasDrawer.Validators;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ICommandValidator, CommandValidator>()
    .AddSingleton<IFigureCreator, FigureCreator>()
    .AddSingleton<IDrawingValidator, DrawingValidator>()
    .AddSingleton<IDrawer, Drawer>()
    .AddSingleton<IConsoleWriter, ConsoleWriter>()
    .AddSingleton<ProgramExecutor>()
    .BuildServiceProvider();

var programExecutor = serviceProvider.GetService<ProgramExecutor>()!;
programExecutor.ReadCanvas();
programExecutor.ReadCommands();