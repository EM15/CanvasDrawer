using CanvasDrawer;

var commandValidator = new CommandValidator();
var programExecutor = new ProgramExecutor(commandValidator);

programExecutor.ReadCanvas();
programExecutor.ReadCommand();