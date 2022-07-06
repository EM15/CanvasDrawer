﻿namespace CanvasDrawer.Drawings
{
    public class Line
    {
        public readonly int X1;
        public readonly int Y1;
        public readonly int X2;
        public readonly int Y2;

        public Line(int x1, int y1, int x2, int y2)
        {
            if (x1 != x2 && y1 != y2)
            {
                throw new ArgumentException("Only vertical and horizontal lines are allowed");
            }

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
    }
}
