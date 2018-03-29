using System;
using System.Collections.Generic;
using System.Text;

namespace MinSpanningTree.BLL.Models
{
    public class Edge: IComparable<Edge>
    {
        public Point First  { get; set; }
        public Point Second { get; set; }
        public double Length { get; set; }

        public Edge(Point p1, Point p2)
        {
            Length = p1.DistanceTo(p2);
            First = p1;
            Second = p2;
        }
        public Edge()
        {

        }

        public int CompareTo(Edge obj)
        {
            if (this.Length > obj.Length)
                return 1;
            if (this.Length < obj.Length)
                return -1;
            else
                return 0;
        }
    }
}
