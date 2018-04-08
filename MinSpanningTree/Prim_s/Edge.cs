using System;
using System.Collections.Generic;
using System.Text;

namespace Prim_s
{
    public class Edge: IComparable<Edge>
    {
        public int v1, v2; //номери вершин ребра

        public double weight; //вага ребра

        public Edge(int v1, int v2, double weight)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.weight = weight;
        }

        public int CompareTo(Edge other)
        {
            if (this.weight > other.weight) return 1;
            else return -1;
        }


    }
}
