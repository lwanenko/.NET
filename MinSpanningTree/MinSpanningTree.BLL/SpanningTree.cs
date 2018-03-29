using MinSpanningTree.BLL.Models;
using System.Collections.Generic;


namespace MinSpanningTree.BLL
{
    public class SpanningTree
    {
        public  SortedSet<Edge> Edges { get; set; }

        public SortedSet<Point> Vertices { get; set; }

        public SpanningTree(List<Point> vertices)
        {
            var triangulator = new Triangulator();

            var triangleGraph = triangulator.Triangulation(vertices);

            var inputEdges = new List<Edge>();
            foreach (var cur in triangleGraph)
            {
                var edge1 = new Edge(cur.points[0], cur.points[1]);
                var edge2 = new Edge(cur.points[1], cur.points[0]);
                if (!(Edges.Contains(edge1) || Edges.Contains(edge2)) )
                    Edges.Add(edge1);

                edge1 = new Edge(cur.points[0], cur.points[2]);
                edge2 = new Edge(cur.points[2], cur.points[0]);
                if (!(Edges.Contains(edge1) || Edges.Contains(edge2)))
                    Edges.Add(edge1);

                edge1 = new Edge(cur.points[1], cur.points[2]);
                edge2 = new Edge(cur.points[2], cur.points[1]);
                if (!(Edges.Contains(edge1) || Edges.Contains(edge2)))
                    Edges.Add(edge1);
            }

            PrimsAlgorithm(inputEdges);
        }

        private void PrimsAlgorithm(List<Edge> inputEdges)
        {
            Quicksort(ref inputEdges, 0, inputEdges.Count - 1);
            Edges.Add(inputEdges[0]);
            Vertices.Add(inputEdges[0].First);
            Vertices.Add(inputEdges[0].Second);         

            for (int i = 2; i < Vertices.Count; i++)
            {

                bool first = true;
                Edge minEdges = new Edge();

                foreach (var cur in inputEdges)
                {
                    if (first)
                    {
                        if(Vertices.Contains(cur.First) && !Vertices.Contains(cur.Second))
                        {
                            minEdges = cur;
                        }
                        if(Vertices.Contains(cur.Second) && !Vertices.Contains(cur.First))
                        {
                            minEdges = cur;
                        }
                    }
                    else
                    {
                        if (minEdges.Length > cur.Length)
                            if (Vertices.Contains(cur.First) && !Vertices.Contains(cur.Second) ||
                                Vertices.Contains(cur.First) && !Vertices.Contains(cur.Second))
                                minEdges = cur;
                    } 
                }
                Edges.Add(minEdges);
            }
        }

        

        public static void Quicksort(ref List<Edge> elements, int left, int right)
        {
            int i = left, j = right;
            Edge pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    Edge tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(ref elements, left, j);
            }
            if (i < right)
            {
                Quicksort(ref elements, i, right);
            }
        }

        

    }
}
