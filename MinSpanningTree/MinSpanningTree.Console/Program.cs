using System;
using System.Collections.Generic;

namespace MinSpanningTree.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<BLL.Models.Point> Points = new List<BLL.Models.Point>();
            for (int i = 0; i < 5; i++)
            {
                var point = new BLL.Models.Point(random.Next(),random.Next());
                Points.Add(point);
            }
            var tree = new MinSpanningTree.BLL.SpanningTree(Points);
            //Console.WriteLine(tree);
        }
    }
}
