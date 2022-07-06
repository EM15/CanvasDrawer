using CanvasDrawer;
using CanvasDrawer.Creators;
using CanvasDrawer.Validators;

// TODO: Implement DI with Singletons
var commandValidator = new CommandValidator();
var drawingCreator = new DrawingCreator();
var drawer = new Drawer();
var programExecutor = new ProgramExecutor(commandValidator, drawingCreator, drawer);

programExecutor.ReadCanvas();
programExecutor.ReadCommand();