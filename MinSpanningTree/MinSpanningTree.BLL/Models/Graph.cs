using System.Collections.Generic;


namespace MinSpanningTree.BLL.Models
{
    /// <summary>
    /// Граф з точок на площині
    /// </summary>
    public class Graph
    {
        public  List<Edge> Edges { get; set; }

        public List<Point> Vertices { get; set; }

        public Graph(List<Point> vertices)
        {
            Vertices = vertices;

        }


    }
}
