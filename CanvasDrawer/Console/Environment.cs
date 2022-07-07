namespace CanvasDrawer.Console
{
    public class Environment : IEnvironment
    {
        public void ExitProgram() => System.Environment.Exit(0);
    }
}
