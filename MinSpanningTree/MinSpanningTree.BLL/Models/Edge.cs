using System;
using System.Collections.Generic;
using System.Text;

namespace MinSpanningTree.BLL.Models
{
    public class Edge
    {
        public Point First  { get; set; }
        public Point Second { get; set; }
        public double Length { get; set; }

        public Edge(Point p1, Point p2)
        {
            Length = p1.Length(p2);
            First = p1;
            Second = p2;
        }


    }
}
