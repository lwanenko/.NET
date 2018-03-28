using System;
using System.Collections.Generic;
using System.Text;

namespace MinSpanningTree.BLL
{
    public class Point
    {
        public double x { get; set; }

        public double y { get; set; }

        public Point(double x, double y)
        {
            this.x = x;

            this.y = y;
        }

        public double Length(Point point)
        {
            return Math.Sqrt((x - point.x)*(x - point.x) + (y - point.y)*(y - point.y));
        }
    }
}
