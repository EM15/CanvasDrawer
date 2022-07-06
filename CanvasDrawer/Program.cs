using CanvasDrawer;
using CanvasDrawer.Creators;
using CanvasDrawer.Validators;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ICommandValidator, CommandValidator>()
    .AddSingleton<IDrawingCreator, DrawingCreator>()
    .AddSingleton<IDrawer, Drawer>()
    .AddSingleton<ProgramExecutor>()
    .BuildServiceProvider();

var programExecutor = serviceProvider.GetService<ProgramExecutor>()!;
programExecutor.ReadCanvas();
programExecutor.ReadCommands();