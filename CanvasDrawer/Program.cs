using CanvasDrawer;

var commandValidator = new CommandValidator();
var drawer = new Drawer();
var programExecutor = new ProgramExecutor(commandValidator, drawer);

programExecutor.ReadCanvas();
programExecutor.ReadCommand();