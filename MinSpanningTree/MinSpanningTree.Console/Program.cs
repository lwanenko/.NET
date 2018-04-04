using System;
using System.Collections.Generic;
using Kruskal;

namespace MinSpanningTree.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            Adjacency adjacency = new Adjacency(9);

            adjacency.setElementAt(true, 0, 1);
            adjacency.setElementAt(true, 0, 7);
            adjacency.setElementAt(true, 1, 2);
            adjacency.setElementAt(true, 1, 7);
            adjacency.setElementAt(true, 2, 3);
            adjacency.setElementAt(true, 2, 5);
            adjacency.setElementAt(true, 2, 8);
            adjacency.setElementAt(true, 3, 4);
            adjacency.setElementAt(true, 3, 5);
            adjacency.setElementAt(true, 4, 5);
            adjacency.setElementAt(true, 5, 6);
            adjacency.setElementAt(true, 6, 7);
            adjacency.setElementAt(true, 6, 8);
            adjacency.setElementAt(true, 7, 8);
            adjacency.setWeight(0, 1, 4);
            adjacency.setWeight(0, 7, 8);
            adjacency.setWeight(1, 2, 8);
            adjacency.setWeight(1, 7, 11);
            adjacency.setWeight(2, 3, 7);
            adjacency.setWeight(2, 5, 4);
            adjacency.setWeight(2, 8, 2);
            adjacency.setWeight(3, 4, 9);
            adjacency.setWeight(3, 5, 14);
            adjacency.setWeight(4, 5, 10);
            adjacency.setWeight(5, 6, 2);
            adjacency.setWeight(6, 7, 1);
            adjacency.setWeight(6, 8, 6);
            adjacency.setWeight(7, 8, 7);

            KruskalMST mst = new KruskalMST();
            Pair[] A = mst.MSTKruskal(9, adjacency);
        }
    }
}
