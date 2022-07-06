namespace CanvasDrawer
{
    public interface ICommandValidator
    {
        bool IsCanvasCommandValid(string? command);
        bool IsDrawingCommandValid(string? command);
    }
}
