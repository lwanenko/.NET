using System;
using System.Collections.Generic;
using System.Text;

namespace MinSpanningTree.BLL.Models
{
    public class Point
    {
        public double x;

        public double y;

        public Point(double x, double y)
        {
            this.x = x;

            this.y = y;
        }
        public Point()
        {
                
        }


        public double DistanceTo(Point other)
        {
            return Math.Sqrt((x - other.x)*(x - other.x) + (y - other.y)*(y - other.y));
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }
    }
}
