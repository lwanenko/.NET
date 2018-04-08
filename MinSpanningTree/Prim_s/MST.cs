using System;
using System.Collections.Generic;
using System.Text;

namespace Prim_s
{
    public class MST
    {
        private List<Edge> MstEdges = new List<Edge>();

        private SortedSet<Edge>[] Edges;

        private ISet<int> OpenV = new SortedSet<int>();

        private bool[] UsedV;

        public List<Edge>  algorithmByPrim(int numberV, List<Edge> edges)
        {
            MstEdges.Clear();
            OpenV.Clear();

            //невикористані ребра
            Edges = new SortedSet<Edge> [numberV];
            for(int i = 0; i < numberV; i++)
                Edges[i] = new SortedSet<Edge>();
            foreach(var cur in edges)
            {
                var _cur = new Edge(cur.v2, cur.v1, cur.weight);
                Edges[cur.v1].Add(cur);
                Edges[cur.v2].Add(_cur);
            }
            
            //використані вершини
            UsedV = new bool [numberV];           
            for (int i = 0; i < numberV; i++)
                UsedV [i] = false;

            //додаємо початкову вершину 0
            UsedV[0] = true;
            AddOpenV(0);

            while(OpenV.Count != 0)
            {
                Edge minE = null;
                int newV = -1;
                foreach (var v  in OpenV )
                {
                    foreach (var edge in Edges[v])
                    {
                        if (minE != null)
                        {
                            if (UsedV[edge.v2] && minE.weight > edge.weight)
                            {
                                minE = edge;
                                break;
                            }
                        }
                        else if (UsedV[edge.v2])
                        {
                            minE = edge;
                            break;
                        }
                    }
                }

                newV = minE.v1;
                //Заносимо нову вершину в списки
                UsedV[newV] = true;
                OpenV.Remove(newV);
                AddOpenV(newV);

                //заносим мінімальне ребро в кістякове дерево
                MstEdges.Add(minE);
            }
            return MstEdges;
        }

        /// <summary>
        /// Оновлює список відкритих вершин
        /// </summary>
        /// <param name="v"></param>
        private void AddOpenV(int v)
        {
            foreach (var edge in Edges[v])
                if (!UsedV[edge.v2])
                    OpenV.Add(edge.v2);
        }
    }
    
}
