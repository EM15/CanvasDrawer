namespace CanvasDrawer.Drawings
{
    public class Line
    {
        public readonly int X1;
        public readonly int Y1;
        public readonly int X2;
        public readonly int Y2;
        public int Length
        {
            get
            {
                if (X1 == X2)
                {
                    return Y2 - Y1;
                }

                return X2 - X1;
            }
        }

        public bool IsHorizontal => Y1 == Y2;

        public Line(int x1, int y1, int x2, int y2)
        {
            // So start position is always from left to right and top to bottom
            X1 = x1 > x2 ? x2 : x1;
            Y1 = y1 > y2 ? y2 : y1;
            X2 = x1 > x2 ? x1 : x2;
            Y2 = y1 > y2 ? y1 : y2;
        }
    }
}
